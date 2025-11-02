namespace Entity.DTOs.Catalog.Movie.Create
{
    public class MovieCreateDto
    {
        public string Title { get; set; }
        public int? ReleaseYear { get; set; }
        public int? DurationMinutes { get; set; }
        public string? Description { get; set; }
    }
}
