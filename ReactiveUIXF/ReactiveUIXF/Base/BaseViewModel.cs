namespace ReactiveUIXF.Base
{
    using ReactiveUI;
    using ReactiveUIXF.Services;
    using System.Reactive.Disposables;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class BaseViewModel : ReactiveObject
    {
        protected readonly ILogService logService;
        protected readonly IApiService apiService;
        protected readonly IAlertDialogService alertDialogService;

        protected ObservableAsPropertyHelper<bool> _IsLoading;
        public bool IsLoading => _IsLoading.Value;

        protected CompositeDisposable disposables;

        public BaseViewModel()
        {
            logService = DependencyService.Get<ILogService>();
            apiService = DependencyService.Get<IApiService>();
            alertDialogService = DependencyService.Get<IAlertDialogService>();

            CreateCommands();
        }

        public virtual Task OnAppearingAsync()
        {
            logService.Log($"Appearing {GetType().ToString()}");
            disposables = disposables ?? new CompositeDisposable();
            return Task.CompletedTask;
        }

        public virtual Task OnDisappearingAsync()
        {
            logService.Log($"Disappearing {GetType().ToString()}");
            disposables?.Dispose();
            disposables = null;
            return Task.CompletedTask;
        }

        // public void Dispose() => Disposables.Dispose();

        protected virtual void CreateCommands()
        { }
    }
}
