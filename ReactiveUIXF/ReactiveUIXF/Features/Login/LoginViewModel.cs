namespace ReactiveUIXF.Features
{
    using ReactiveUI;
    using ReactiveUI.Fody.Helpers;
    using ReactiveUIXF.Base;
    using System.Reactive;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        string email;
        string password;

        public string Email
        {
            get => email;
            set { this.RaiseAndSetIfChanged(ref email, value); }
        }

        public string Password
        {
            get => password;
            set { this.RaiseAndSetIfChanged(ref password, value); }
        }

        public extern bool IsValid { [ObservableAsProperty] get; }

        public ReactiveCommand<Unit, Unit> LoginCommand { get; set; }

        protected override void CreateCommands()
        {
            var canExecute = this.WhenAnyValue(e => e.Email, p => p.Password, (email, password)
                => (!string.IsNullOrEmpty(email) && email.Length >= 5 &&
                    !string.IsNullOrEmpty(password) &&
                    password.Length > 6)); // .ToProperty(this, v => v.IsValid)

            //var canExecute = this.WhenAnyValue(x => x.IsVisible, x => x.IsValid, 
            //                (isLoading, IsValid) => !isLoading && IsValid);

            LoginCommand = ReactiveCommand.CreateFromTask(Login, canExecute);

            this.WhenAnyObservable(x => x.LoginCommand.IsExecuting);
        }

        private async Task Login()
        {
            NavigationPage navigationPage = new NavigationPage(new FilmView() { ViewModel = new FilmViewModel() });
            Application.Current.MainPage = navigationPage;
        }
    }
}
