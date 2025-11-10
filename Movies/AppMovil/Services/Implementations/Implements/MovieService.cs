using AppMovil.Models.Implements.Movies;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.Services.Http;
using AppMovil.Services.Implementations.Generic;

namespace AppMovil.Services.Implementations.Implements
{
    public class MovieService : GenericService<MovieSelectDto, MovieCreateDto, MovieUpdateDto>, IMovieService
    {
        public MovieService(ApiClient api) : base(api, "Movie")
        {
        }
    }
}
