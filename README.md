# Reactive UI for Xamarin Forms


## Install ##

[Nuget package ReactiveUI.XamForms](https://www.nuget.org/packages/ReactiveUI.XamForms/10.5.7/)

> Install-Package ReactiveUI.XamForms

[Nuget package ReactiveUI.Events.XamFor](https://www.nuget.org/packages/ReactiveUI.Events.XamForms/10.5.7/)

> Install-Package ReactiveUI.Events.XamFor

[Nuget package ReactiveUI.Fody](https://www.nuget.org/packages/ReactiveUI.Fody/10.5.7/):

> Install-Package ReactiveUI.Fody

## ViewModels ##

All our ViewModels must inherit from Reactive Object which implements the INotifyPropertyChanged interface for us. Another feature of ReactiveUI is that the initialization of our properties and Commands is done in the ViewModels constructor.

To initialize our properties and commands we do it through the contructor of our ViewModels.

## Data Binding ##

**Bind**: - Sets up a two-way binding between a property on the ViewModel to the View.

    this.WhenActivated(disposables =>
    {
        this.Bind(ViewModel,
            viewModel => viewModel.UserName,
            view => view.UserName.Text);

        this.Bind(ViewModel,
             viewModel => viewModel.Password,
             view => view.Password.Text);
    });
    
**OneWayBind**: - Sets up a one-way binding from a property on the ViewModel to the View.
    
    this.WhenActivated(disposables =>
    {
        this.WhenAnyValue(x => x.ViewModel.LoadCommand)
            .Where(x => x != null)
            .Select(x => Unit.Default)
            .InvokeCommand(ViewModel.LoadCommand); 
         
        this.OneWayBind(ViewModel, vm => vm.Films, v => v.FilmList.ItemsSource)
             .DisposeWith(disposables);
             
        this.OneWayBind(ViewModel, vm => vm.LoadingFilms, v => v.Loading.IsVisible)
             .DisposeWith(disposables);
    });

**BindCommand**: - Bind an ICommand to a control, or to a specific event on that control. View model commands that need to be bound to view controls must implement the ICommand interface. View model commands are typically bound to view controls using one of the BindCommand overloads available in the view:

    this.BindCommand(this.ViewModel, vm => vm.LoginCommand,
        v => v.BtnLogin,
        nameof(BtnLogin.Clicked));
        
**Reactive Properties**

Eases the need for boilerplate in your view models when using [reactiveui](https://github.com/reactiveui/ReactiveUI).  Typically, in your view models you must declare properties like this:

    string _name;
    
    public string Name 
    {
        get { return _name; }
        set { this.RaiseAndSetIfChanged(ref _name, value); }
    }

This is tedious since all you'd like to do is declare properties as normal:

    [Reactive]public string Name { get; set; }
    
If a property is annotated with the `[Reactive]` attribute, the plugin will weave the boilerplate into your 
output based on the simple auto-property declaration you provide.  

## Dependency Inversion - Splat ##

**Registration**

    public class AppBootstrapper : IEnableLogger
    {
        public static AppBootstrapper Instance { get; } = new AppBootstrapper();

        public AppBootstrapper()
        {
            RegisterDependencies();
        }

        public void RegisterDependencies()
        {
            Locator.CurrentMutable.RegisterConstant(new NavigationService(), typeof(INavigationService));
            Locator.CurrentMutable.RegisterConstant(new AuthenticationService(), typeof(IAuthenticationService));
        }
    }

**Resolution**

    var navigationService = Locator.Current.GetService<INavigationService>();
    
**The best way to use Service Locator**

Splat provides methods to resolve dependencies to single or multiple instances.

    var navigationService = Locator.Current.GetService<INavigationService>();
    var allnavigationService = Locator.Current.GetServices<INavigationService>();
    
Recommended usage is:

    public NavigationService(IAuthenticationService authenticationService = null)
    {
        _authenticationService = authenticationService ?? Locator.Current.GetService<IAuthenticationService>();
        
        mappings = new Dictionary<Type, Type>(); 
        CreatePageViewModelMappings();
    }

## Tools used

* [Visual Studio for mac and windows](https://visualstudio.microsoft.com)
* [LiveXAML](http://www.livexaml.com) - Live simulator updates for your XAML code 
* [Mfractor](https://www.mfractor.com) - MFractor is the essential productivity tool for Visual Studio Mac
* [Json to C#](https://quicktype.io/csharp/) - Generate models and serializers from JSON and schema

## Licenses

This project uses some third-party assets with a license that requires attribution:

- [Newtonsoft](https://www.newtonsoft.com/json) : by James NK
- [MVVM Helpers](https://www.nuget.org/packages/Refractored.MvvmHelpers/) : by James Montemagno
- [Xamarin.Essentials](https://www.nuget.org/packages/Xamarin.Essentials) : by James Montemagno
- [Reactive ui](https://github.com/reactiveui/reactiveui#net-foundation) : ReactiveUI is part of the .NET Foundation. Other projects that are associated with the foundation include the Microsoft .NET Compiler Platform ("Roslyn") as well as the Microsoft ASP.NET family of projects, Microsoft .NET Core & Xamarin Forms.

## Dario youtube channel

- [First talk about reactive](https://www.youtube.com/watch?v=LVQk7tMyUy8)

## Links

- [Reactive ui guidelines](https://reactiveui.net/docs/guidelines/platform/xamarin-forms)
- [Reactive ui installation](https://reactiveui.net/docs/getting-started/installation/)
- [Dependency inversion - Splat](https://reactiveui.net/docs/handbook/dependency-inversion/)
- [Data Binding](https://reactiveui.net/docs/handbook/data-binding/)
- [Binding Commands](https://reactiveui.net/docs/handbook/commands/binding-commands)

## Clean and Rebuild

If you see build issues when pulling updates from the repo, try cleaning and rebuilding the solution.

## Copyright and license

The MIT License (MIT) see [License file](https://github.com/jorgemht/ReactiveUIXF/blob/master/LICENSE)
