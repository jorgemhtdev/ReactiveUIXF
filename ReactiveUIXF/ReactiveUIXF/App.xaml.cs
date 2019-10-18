namespace ReactiveUIXF
{
    using ReactiveUIXF.Services.Api;
    using ReactiveUIXF.Services.Interfaces;
    using ReactiveUIXF.Views;
    using ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ServiceDependency();

            MainPage = new FilmView()
            {
                ViewModel = new FilmViewModel()
            };
        }

        private void ServiceDependency()
        {
            DependencyService.Register<IApiService, ApiService>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
