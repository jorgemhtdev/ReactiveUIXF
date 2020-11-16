namespace ReactiveUIXF.Features
{
    using ReactiveUI;
    using ReactiveUI.XamForms;
    using System.Reactive.Disposables;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ReactiveContentPage<LoginViewModel>
    {
        public LoginView()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                this.BindCommand(this.ViewModel, vm => vm.LoginCommand,
                    v => v.BtnLogin,
                    nameof(BtnLogin.Clicked)).DisposeWith(disposables);

                this.Bind(ViewModel,
                    viewModel => viewModel.Email,
                    view => view.Email.Text).DisposeWith(disposables);

                this.Bind(ViewModel,
                    viewModel => viewModel.Password,
                    view => view.Password.Text).DisposeWith(disposables);
            });
        }
    }
}