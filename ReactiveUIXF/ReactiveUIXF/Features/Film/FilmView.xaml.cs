namespace ReactiveUIXF.Features
{
    using ReactiveUI;
    using ReactiveUI.XamForms;
    using System;
    using System.Reactive;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;

    public partial class FilmView : ReactiveContentPage<FilmViewModel>
    {
        public FilmView()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                this.WhenAnyValue(x => x.ViewModel.LoadCommand)
                    .Where(x => x != null)
                    .Select(x => Unit.Default)
                    .InvokeCommand(ViewModel.LoadCommand);

                this.Bind(ViewModel, vm => vm.Search, v => v.SearchText.Text)
                    .DisposeWith(disposables);

                this.OneWayBind(ViewModel, vm => vm.Films, v => v.FilmList.ItemsSource)
                    .DisposeWith(disposables);

                //this.OneWayBind(ViewModel, vm => vm.Loading, v => v.Loading.IsVisible)
                    //.DisposeWith(disposables);
            });
        }
    }
}