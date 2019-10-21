namespace ReactiveUIXF.ViewModels
{
    using ReactiveUI;
    using ReactiveUI.Fody.Helpers;
    using ReactiveUIXF.Models;
    using ReactiveUIXF.Services.Authentication;
    using ReactiveUIXF.ViewModels.Base;
    using Splat;
    using System;
    using System.Reactive;
    using System.Threading.Tasks;

    public class LoginViewModel : ViewModelBase
    {
        protected readonly IAuthenticationService _authenticationService;

        private User user { [ObservableAsProperty] get; }

        public extern string Email { [ObservableAsProperty] get; }
        public extern string Password { [ObservableAsProperty] get; }

        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        public LoginViewModel(IAuthenticationService authenticationService = null)
        {
            _authenticationService = authenticationService ?? Locator.Current.GetService<IAuthenticationService>();

            LoginCommand = ReactiveCommand.CreateFromTask(Login);
        }

        private async Task Login()
        {
            var result = await _authenticationService.LoginAsync(Email, Password);

            if(result)
                await NavigationService.NavigateToAsync<FilmViewModel>();
        }
    }
}
