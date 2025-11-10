namespace AppMovil.Models.Implements.Movies
{
    public class MovieCreateDto
    {
        public string Title { get; set; }
        public int? ReleaseYear { get; set; }
        public int? DurationMinutes { get; set; }
        public string? Description { get; set; }
    }
}
