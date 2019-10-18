namespace ReactiveUIXF
{
    using ReactiveUIXF.Services.Api;
    using ReactiveUIXF.Services.Interfaces;
    using ReactiveUIXF.Views;
    using Xamarin.Forms;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ServiceDependency();

            MainPage = new FilmView();
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
