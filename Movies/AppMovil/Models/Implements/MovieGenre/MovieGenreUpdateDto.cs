using AppMovil.Models.Base;

namespace AppMovil.Models.Implements.MovieGenre;

public sealed class MovieGenreUpdateDto : BaseDto
{
    public int MovieId { get; set; }
    public int GenreId { get; set; }
}
