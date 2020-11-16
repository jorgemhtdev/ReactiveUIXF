namespace ReactiveUIXF
{
    using ReactiveUIXF.Features;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            NavigationPage navigationPage = new NavigationPage(new LoginView() { ViewModel = new LoginViewModel() });
            NavigationPage.SetHasNavigationBar(navigationPage.CurrentPage, false);
            MainPage = navigationPage;
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
