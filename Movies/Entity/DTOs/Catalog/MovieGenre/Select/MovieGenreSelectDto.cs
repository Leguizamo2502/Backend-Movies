using Entity.DTOs.Base;

namespace Entity.DTOs.Catalog.MovieGenre.Select
{
    public class MovieGenreSelectDto : BaseDto
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
