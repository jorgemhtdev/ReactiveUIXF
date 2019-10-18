namespace ReactiveUIXF.ViewModels
{
    using ReactiveUIXF.Services.Interfaces;
    using ReactiveUIXF.ViewModels.Base;
    using Xamarin.Forms;

    public class FilmViewModel : ViewModelBase
    {
        public FilmViewModel() 
        {
            LoadData();
        }

        private async void LoadData()
        {
            var x = await DependencyService.Get<IApiService>().GetAllFilm();
        }
    }
}
