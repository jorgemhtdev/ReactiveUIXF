# Reactive UI for Xamarin Forms


## Install ##
Nuget package ReactiveUI.Fody:

> Install-Package ReactiveUI.Fody

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

## Tools used

* [Visual Studio for mac and windows](https://visualstudio.microsoft.com)
* [LiveXAML](http://www.livexaml.com) - Live simulator updates for your XAML code 
* [Mfractor](https://www.mfractor.com) - MFractor is the essential productivity tool for Visual Studio Mac

## Licenses

This project uses some third-party assets with a license that requires attribution:

- [Newtonsoft](https://www.newtonsoft.com/json) : by James NK
- [MVVM Helpers](https://www.nuget.org/packages/Refractored.MvvmHelpers/) : by James Montemagno
- [Xamarin.Essentials](https://www.nuget.org/packages/Xamarin.Essentials) : by James Montemagno
- [Reactive ui](https://github.com/reactiveui/reactiveui#net-foundation) : ReactiveUI is part of the .NET Foundation. Other projects that are associated with the foundation include the Microsoft .NET Compiler Platform ("Roslyn") as well as the Microsoft ASP.NET family of projects, Microsoft .NET Core & Xamarin Forms.

## Dario youtube channel

- [first talk about reactive](https://www.youtube.com/watch?v=LVQk7tMyUy8)

## Links

- [Reactive ui guidelines](https://reactiveui.net/docs/guidelines/platform/xamarin-forms)
- [Reactive ui installation](https://reactiveui.net/docs/getting-started/installation/)

## Clean and Rebuild

If you see build issues when pulling updates from the repo, try cleaning and rebuilding the solution.

## Copyright and license

The MIT License (MIT) see [License file](https://github.com/jorgemht/ReactiveUIXF/blob/master/LICENSE)
