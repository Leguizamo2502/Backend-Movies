using AppMovil.Models.Implements.MovieGenre;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.Services.Http;
using AppMovil.Services.Implementations.Generic;

namespace AppMovil.Services.Implementations.Implements;

public sealed class MovieGenreService : GenericService<MovieGenreSelectDto, MovieGenreCreateDto, MovieGenreUpdateDto>, IMovieGenreService
{
    public MovieGenreService(ApiClient api) : base(api, "MovieGenre")
    {
    }
}
