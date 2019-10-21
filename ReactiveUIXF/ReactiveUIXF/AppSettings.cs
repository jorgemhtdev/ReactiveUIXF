namespace ReactiveUIXF
{
    using ReactiveUIXF.Models;
    using ReactiveUIXF.Utils;
    using Xamarin.Essentials;

    public static class AppSettings
    {    
        //App Center
        const string defaultAppCenterAndroid = "";
        const string defaultAppCenteriOS = "";

        public static string ApiBaseUrl = "https://my-json-server.typicode.com/";

        public static User User
        {
            get => PreferencesHelpers.Get(nameof(User), default(User));
            set => PreferencesHelpers.Set(nameof(User), value);
        }

        public static void RemoveUserData() 
        {
            Preferences.Remove(nameof(User));
            SecureStorage.RemoveAll();
        }
    }
}
