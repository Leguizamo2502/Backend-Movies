using AppMovil.Models.Base;

namespace AppMovil.Models.Implements.MovieGenre;

public sealed class MovieGenreSelectDto : BaseDto
{
    public int MovieId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int GenreId { get; set; }
    public string GenreName { get; set; } = string.Empty;
}
