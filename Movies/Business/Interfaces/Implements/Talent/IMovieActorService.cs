using Business.Interfaces.BaseService;
using Entity.DTOs.Talent.MovieActor.Create;
using Entity.DTOs.Talent.MovieActor.Select;
using Entity.DTOs.Talent.MovieActor.Update;

namespace Business.Interfaces.Implements.Talent
{
    public interface IMovieActorService : IBaseBusiness<MovieActorSelectDto,MovieActorCreateDto,MovieActorUpdatetDto>
    {
    }
}
