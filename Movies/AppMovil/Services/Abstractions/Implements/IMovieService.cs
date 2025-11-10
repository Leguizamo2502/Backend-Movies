using AppMovil.Models.Implements.Movies;
using AppMovil.Services.Abstractions.Generic;

namespace AppMovil.Services.Abstractions.Implements
{
    public interface IMovieService : IGenericService<MovieSelectDto,MovieCreateDto,MovieUpdateDto>
    {
    }
}
