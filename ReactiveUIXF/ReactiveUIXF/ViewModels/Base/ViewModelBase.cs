namespace ReactiveUIXF.ViewModels.Base
{
    using ReactiveUI;
    using System;
    using System.Reactive.Disposables;

    public class ViewModelBase : ReactiveObject, IDisposable
    {
        protected CompositeDisposable Disposables;

        protected ViewModelBase()
        {
            Disposables = new CompositeDisposable();
        }

        public void Dispose()
        {
            Disposables.Dispose();
        }
    }
}
