using Business.Interfaces.BaseService;
using Entity.DTOs.Talent.Actor.Create;
using Entity.DTOs.Talent.Actor.Select;
using Entity.DTOs.Talent.Actor.Update;

namespace Business.Interfaces.Implements.Talent
{
    public interface IActorService : IBaseBusiness<ActorSelectDto,ActorCreateDto,ActorUpdateDto>
    {
    }
}
