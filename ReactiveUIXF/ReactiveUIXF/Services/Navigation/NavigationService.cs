namespace ReactiveUIXF.Services.Navigation
{
    using ReactiveUIXF.Services.Authentication;
    using ReactiveUIXF.ViewModels.Base;
    using System.Collections.Generic;
    using ReactiveUIXF.ViewModels;
    using System.Threading.Tasks;
    using ReactiveUIXF.Views;
    using Xamarin.Forms;
    using Splat;
    using System;

    public partial class NavigationService : INavigationService
    {
        protected readonly IAuthenticationService _authenticationService;
        protected readonly Dictionary<Type, Type> mappings;

        protected Application CurrentApplication => Application.Current;

        public NavigationService(IAuthenticationService authenticationService = null)
        {
            _authenticationService = authenticationService ?? Locator.Current.GetService<IAuthenticationService>();

            mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }

        public async Task InitializeAsync()
        {
            if (_authenticationService.UserIsAuthenticatedAndValidAsync())
            {
               await NavigateToAsync<FilmViewModel>();
            }
            else
            {
                await NavigateToAsync<LoginViewModel>();
            }
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase => InternalNavigateToAsync(typeof(TViewModel), null);

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase => InternalNavigateToAsync(typeof(TViewModel), parameter);

        public Task NavigateToAsync(Type viewModelType) => InternalNavigateToAsync(viewModelType, null);

        public Task NavigateToAsync(Type viewModelType, object parameter) => InternalNavigateToAsync(viewModelType, parameter);

        public async Task NavigateBackAsync()
        {
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {

            return Task.FromResult(true);
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            var page = CreateAndBindPage(viewModelType, parameter);

            if (page is FilmView)
            {
                CurrentApplication.MainPage = page;
            }
            else if (page is LoginView)
            {
                CurrentApplication.MainPage = page;
            }

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            var pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            var page = Activator.CreateInstance(pageType) as Page;
            var viewModel = Locator.Current.GetService(viewModelType);

            page.BindingContext = viewModel;

            return page;
        }

        void CreatePageViewModelMappings()
        {
            mappings.Add(typeof(FilmViewModel), typeof(FilmView));
            mappings.Add(typeof(LoginViewModel), typeof(LoginView));

            if (Device.Idiom == TargetIdiom.Desktop) { } else { }
        }
    }
}
