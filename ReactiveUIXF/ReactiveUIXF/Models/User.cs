namespace ReactiveUIXF.Models
{
    using Newtonsoft.Json;
    using ReactiveUI.Fody.Helpers;

    public class User
    {
        [JsonProperty("userId")]
        [Reactive] public long UserId { get; set; }

        [JsonProperty("email")]
        [Reactive] public string Email { get; set; }

        [JsonProperty("password")]
        [Reactive] public string Password { get; set; }
    }
}
