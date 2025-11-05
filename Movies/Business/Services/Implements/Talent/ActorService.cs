using Business.Interfaces.Implements.Talent;
using Business.Services.BaseService;
using Data.Interfaces.DataGeneric;
using Entity.Domain.Models.Implements.Talent;
using Entity.DTOs.Talent.Actor.Create;
using Entity.DTOs.Talent.Actor.Select;
using Entity.DTOs.Talent.Actor.Update;
using MapsterMapper;

namespace Business.Services.Implements.Talent
{
    public class ActorService : BaseBusiness<Actor, ActorSelectDto, ActorCreateDto, ActorUpdateDto>, IActorService
    {
        public ActorService(IMapper mapper, IDataGeneric<Actor> data) : base(mapper, data)
        {
        }
    
    }
}
