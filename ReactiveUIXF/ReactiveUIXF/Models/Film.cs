namespace ReactiveUIXF.Models
{
    using Newtonsoft.Json;

    public class Film
    {
        [JsonProperty("filmId")]
        public long FilmId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("originalTitle")]
        public string OriginalTitle { get; set; }

        [JsonProperty("imdb")]
        public string Imdb { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }
    }
}
