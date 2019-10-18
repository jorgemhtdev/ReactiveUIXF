namespace ReactiveUIXF.Models
{
    using ReactiveUI.Fody.Helpers;

    public class Film
    {
        [Reactive] public string IdFilm { get; set; }
        [Reactive] public string Name { get; set; }
    }
}
