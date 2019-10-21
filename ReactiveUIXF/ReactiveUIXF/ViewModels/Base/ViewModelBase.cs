namespace ReactiveUIXF.ViewModels.Base
{
    using ReactiveUIXF.Services.Navigation;
    using System.Reactive.Disposables;
    using ReactiveUIXF.Services.Api;
    using ReactiveUI.Fody.Helpers;
    using System.Threading.Tasks;
    using ReactiveUI;
    using Splat;
    using System;

    public class ViewModelBase : ReactiveObject, IDisposable
    {
        protected CompositeDisposable Disposables;
        protected readonly INavigationService NavigationService;
        protected readonly IApiService ApiService;
        protected extern bool Loading { [ObservableAsProperty] get; }

        protected ViewModelBase()
        {
            Disposables = new CompositeDisposable();
            NavigationService = Locator.Current.GetService<INavigationService>();
            ApiService = Locator.Current.GetService<IApiService>();
        }

        public void Dispose() => Disposables.Dispose();

        public virtual Task InitializeAsync(object navigationData) => Task.FromResult(false);
    }
}
