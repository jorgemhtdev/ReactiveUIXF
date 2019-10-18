namespace ReactiveUIXF.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IApiService
    {
        Task<IEnumerable<Models.Film>> GetAllFilm();
    }
}
