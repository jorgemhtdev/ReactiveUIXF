namespace ReactiveUIXF.Base
{
    using ReactiveUI;
    using ReactiveUI.XamForms;
    using ReactiveUIXF.Services;
    using System.Reactive.Disposables;
    using Xamarin.Forms;
    using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

    public class BaseContentPage<TViewModel> : ReactiveContentPage<TViewModel> where TViewModel : BaseViewModel
    {
        protected readonly ILogService logService;

        public BaseContentPage()
        {
            logService = DependencyService.Get<ILogService>();

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            this.WhenActivated(d => DefineBindings(d));
        }

        protected CompositeDisposable DefineBindings(CompositeDisposable disposables)
        {
            logService.Log($"Creating bindings {GetType().ToString()}");
            CreateBindings(disposables);
            return disposables;
        }

        protected virtual void CreateBindings(CompositeDisposable disposables)
        { }

        protected override void OnAppearing()
        {
            logService.Log($"Appearing {GetType().ToString()}");
            base.OnAppearing();
            ViewModel?.OnAppearingAsync();
        }

        protected override void OnDisappearing()
        {
            logService.Log($"Disappearing {GetType().ToString()}");
            base.OnDisappearing();
            ViewModel?.OnDisappearingAsync();
        }
    }
}
