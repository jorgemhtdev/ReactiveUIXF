namespace ReactiveUIXF.Services.Film
{
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Headers("User-Agent:application/json")]
    public interface IFilmService
    {
        [Get("/jorgemht/demo/film")]
        Task<IEnumerable<Models.Film>> GetAllFilm();
    }
}
