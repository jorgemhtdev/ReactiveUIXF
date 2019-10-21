namespace ReactiveUIXF.ViewModels
{
    using Models;
    using System;
    using ReactiveUI;
    using DynamicData;
    using System.Reactive;
    using ReactiveUI.Fody.Helpers;
    using ReactiveUIXF.ViewModels.Base;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Reactive.Linq;
    using System.Reactive.Threading.Tasks;

    public class FilmViewModel : ViewModelBase
    {
        private SourceList<Film> _filmData;

        private ReadOnlyObservableCollection<Film> _films;

        public ReadOnlyObservableCollection<Film> Films => _films;

        public extern bool LoadingFilms { [ObservableAsProperty] get; }

        public ReactiveCommand<Unit, IEnumerable<Film>> LoadCommand { get; }

        public FilmViewModel()
        {
            _filmData = new SourceList<Film>();

            LoadCommand = ReactiveCommand.CreateFromObservable(LoadData);
            LoadCommand.IsExecuting.ToPropertyEx(this, x => x.LoadingFilms);
            LoadCommand.Subscribe(_filmData.AddRange);

            _filmData.Connect()
                .Bind(out _films)
                .DisposeMany()
                .Subscribe();
        }

        private IObservable<IEnumerable<Film>> LoadData() => ApiService.GetAllFilm().ToObservable();
    }
}