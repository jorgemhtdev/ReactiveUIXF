namespace ReactiveUIXF.Models
{
    using Newtonsoft.Json;
    using ReactiveUI.Fody.Helpers;

    public class Film
    {
        [JsonProperty("filmId")]
        [Reactive] public long FilmId { get; set; }

        [JsonProperty("title")]
        [Reactive] public string Title { get; set; }

        [JsonProperty("originalTitle")]
        [Reactive] public string OriginalTitle { get; set; }

        [JsonProperty("imdb")]
        [Reactive] public string Imdb { get; set; }

        [JsonProperty("year")]
        [Reactive] public string Year { get; set; }

        [JsonProperty("duration")]
        [Reactive] public string Duration { get; set; }
    }
}
