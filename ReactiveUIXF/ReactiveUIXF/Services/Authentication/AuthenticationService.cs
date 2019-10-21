namespace ReactiveUIXF.Services.Authentication
{
    using System.Threading.Tasks;

    public class AuthenticationService : IAuthenticationService
    {
        public bool IsAuthenticated => AppSettings.User != null;

        public async Task<bool> LoginAsync(string email, string password)
        {
            //var user = new User
            //{
            //    Email = email,
            //};

            //await SecureStorage.SetAsync("password", password);

            //AppSettings.User = user;

            return await Task.FromResult(true);
        }

        public bool UserIsAuthenticatedAndValidAsync() => IsAuthenticated;

        public void LogoutAsync() => AppSettings.RemoveUserData();
    }
}
