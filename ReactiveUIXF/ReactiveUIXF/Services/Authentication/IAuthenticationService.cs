namespace ReactiveUIXF.Services.Authentication
{
    using Models;
    using System.Threading.Tasks;

    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }

        Task<bool> LoginAsync(string email, string password);

        bool UserIsAuthenticatedAndValidAsync();

        void LogoutAsync();
    }
}
