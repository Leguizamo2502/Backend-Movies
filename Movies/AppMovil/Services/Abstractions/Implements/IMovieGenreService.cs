using AppMovil.Models.Implements.MovieGenre;
using AppMovil.Services.Abstractions.Generic;

namespace AppMovil.Services.Abstractions.Implements;

public interface IMovieGenreService : IGenericService<MovieGenreSelectDto, MovieGenreCreateDto, MovieGenreUpdateDto>
{
}
