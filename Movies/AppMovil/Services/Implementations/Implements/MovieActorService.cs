using AppMovil.Models.Implements.MovieActor;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.Services.Http;
using AppMovil.Services.Implementations.Generic;

namespace AppMovil.Services.Implementations.Implements;

public sealed class MovieActorService : GenericService<MovieActorSelectDto, MovieActorCreateDto, MovieActorUpdateDto>, IMovieActorService
{
    public MovieActorService(ApiClient api) : base(api, "MovieActor")
    {
    }
}
