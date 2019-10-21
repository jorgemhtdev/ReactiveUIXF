namespace ReactiveUIXF.Services.Api
{
    using ReactiveUIXF.Services.Interfaces;
    using ReactiveUIXF.CustomException;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ReactiveUIXF.Models;
    using Xamarin.Essentials;

    public class ApiService : IApiService
    {
        private bool _hasInternet;

        public ApiService()
        {
            _hasInternet = Connectivity.NetworkAccess == NetworkAccess.Internet;
            Connectivity.ConnectivityChanged += ConnectivityOnConnectivityChanged;
        }

        public async Task <IEnumerable<Film>> GetAllFilm()
        {
            if (!_hasInternet) throw new ConnectivityException();

            return await Refit.RestService.For<IFilmService>("https://my-json-server.typicode.com/").GetAllFilm();
        }
        private void ConnectivityOnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
            => _hasInternet = e.NetworkAccess == NetworkAccess.Internet;
    }
}
