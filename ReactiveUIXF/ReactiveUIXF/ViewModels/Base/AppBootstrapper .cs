namespace ReactiveUIXF.ViewModels.Base
{
    using ReactiveUIXF.Services.Authentication;
    using ReactiveUIXF.Services.Navigation;
    using ReactiveUIXF.Services.Api;
    using Splat;

    public class AppBootstrapper : IEnableLogger
    {
        public static AppBootstrapper Instance { get; } = new AppBootstrapper();

        public AppBootstrapper() { }

        private void RegisterDependencies()
        {
            Locator.CurrentMutable.RegisterConstant(new AuthenticationService(), typeof(IAuthenticationService));
            Locator.CurrentMutable.RegisterConstant(new NavigationService(), typeof(INavigationService));
            Locator.CurrentMutable.RegisterConstant(new ApiService(), typeof(IApiService));

            Locator.CurrentMutable.RegisterConstant(new LoginViewModel());
            Locator.CurrentMutable.RegisterConstant(new FilmViewModel());

        }

        //public T Resolve<T>() => Locator.Current.GetService<T>();

        //public object Resolve(Type type) => 

        // void Register<TInterface, TImplementation>() where TImplementation : TInterface => Locator.CurrentMutable.RegisterConstant(typeof(TImplementation), typeof(TInterface));

        //public void Register<T>() where T : class => containerBuilder.RegisterType<T>();

        public void Build() => RegisterDependencies();
    }
}
