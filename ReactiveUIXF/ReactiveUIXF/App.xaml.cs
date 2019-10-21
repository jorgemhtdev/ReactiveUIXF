namespace ReactiveUIXF
{
    using ReactiveUIXF.Services.Navigation;
    using ReactiveUIXF.ViewModels.Base;
    using System.Threading.Tasks;
    using Xamarin.Forms.Xaml;
    using Xamarin.Forms;
    using Splat;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Build();

            InitNavigation();
        }
        void Build() => AppBootstrapper.Instance.Build();
        
        private Task InitNavigation()
        {
            var navigationService = Locator.Current.GetService<INavigationService>();

            return navigationService.InitializeAsync();
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
