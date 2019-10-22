namespace ReactiveUIXF.ViewModels
{
    using Models;
    using System;
    using ReactiveUI;
    using DynamicData;
    using System.Reactive;
    using System.Reactive.Linq;
    using ReactiveUI.Fody.Helpers;
    using System.Collections.Generic;
    using ReactiveUIXF.ViewModels.Base;
    using System.Collections.ObjectModel;
    using System.Reactive.Threading.Tasks;

    public class FilmViewModel : ViewModelBase
    {
        private SourceList<Film> _filmData;

        private ReadOnlyObservableCollection<Film> _films;

        public ReadOnlyObservableCollection<Film> Films => _films;

        [Reactive] public string Search { get; set; }

        public ReactiveCommand<Unit, IEnumerable<Film>> LoadCommand { get; private set; }

        public FilmViewModel()
        {
            _filmData = new SourceList<Film>();

            ConfigureLoadCommand();

            var filter = this.WhenAnyValue(x => x.Search)
                .Throttle(TimeSpan.FromMilliseconds(500))
                .Select(BuildFilter);

            _filmData.Connect()
                .Filter(filter)
                .Bind(out _films)
                .DisposeMany()
                .Subscribe();
        }

        private void ConfigureLoadCommand()
        {
            LoadCommand = ReactiveCommand.CreateFromObservable(LoadData);
            LoadCommand.IsExecuting.ToPropertyEx(this, x => x.Loading);
            LoadCommand.Subscribe(_filmData.AddRange);
        }

        private IObservable<IEnumerable<Film>> LoadData() => ApiService.GetAllFilm().ToObservable();

        private static Func<Film, bool> BuildFilter(string searchText)
        {
            if (string.IsNullOrEmpty(searchText)) return repository => true;

            return repo => repo.Title.ToLower().Contains(searchText.ToLower()) || repo.OriginalTitle.ToLower().Contains(searchText.ToLower());
        }
    }
}