[assembly: Xamarin.Forms.Dependency(typeof(ReactiveUIXF.Services.ApiService))]
namespace ReactiveUIXF.Services
{
    using ReactiveUIXF.Models;
    using ReactiveUIXF.Services.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xamarin.Essentials;

    public class ApiService : IApiService
    {
        private bool _hasInternet;

        public ApiService()
        {
            //_hasInternet = Connectivity.NetworkAccess == NetworkAccess.Internet;
            //Connectivity.ConnectivityChanged += ConnectivityOnConnectivityChanged;
        }

        public async Task <IEnumerable<Film>> GetAllFilm()
        {
            //if (!_hasInternet) throw new ConnectivityException();

            return await Refit.RestService.For<IFilmService>("https://my-json-server.typicode.com/").GetAllFilm();
        }
        //private void ConnectivityOnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        //    => _hasInternet = e.NetworkAccess == NetworkAccess.Internet;
    }
}
