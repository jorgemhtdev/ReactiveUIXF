namespace ReactiveUIXF.Services.Api
{
    using ReactiveUIXF.CustomException;
    using ReactiveUIXF.Models;
    using ReactiveUIXF.Services.Film;
    using ReactiveUIXF.Services.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xamarin.Essentials;

    public class ApiService : IApiService
    {
        private IFilmService filmService;
        private bool _hasInternet;

        public ApiService()
        {
            _hasInternet = Connectivity.NetworkAccess == NetworkAccess.Internet;
            Connectivity.ConnectivityChanged += ConnectivityOnConnectivityChanged;
        }

        public async Task <IEnumerable<Film>> GetAllFilm()
        {
            if (!_hasInternet)
                throw new ConnectivityException();

            filmService = Refit.RestService.For<IFilmService>("https://my-json-server.typicode.com/");

            return await filmService.GetAllFilm();
        }
        private void ConnectivityOnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            _hasInternet = e.NetworkAccess == NetworkAccess.Internet;
        }
    }
}
