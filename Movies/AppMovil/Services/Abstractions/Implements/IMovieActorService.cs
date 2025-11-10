using AppMovil.Models.Implements.MovieActor;
using AppMovil.Services.Abstractions.Generic;

namespace AppMovil.Services.Abstractions.Implements;

public interface IMovieActorService : IGenericService<MovieActorSelectDto, MovieActorCreateDto, MovieActorUpdateDto>
{
}
