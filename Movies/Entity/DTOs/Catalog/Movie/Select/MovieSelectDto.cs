using Entity.DTOs.Base;

namespace Entity.DTOs.Catalog.Movie.Select
{
    public class MovieSelectDto : BaseDto
    {
        public string Title { get; set; }
        public int? ReleaseYear { get; set; }
        public int? DurationMinutes { get; set; }
        public string? Description { get; set; }
    }
}
