using Entity.DTOs.Base;

namespace Entity.DTOs.Catalog.MovieGenre.Update
{
    public class MovieGenreUpdateDto : BaseDto
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }
    }
}
