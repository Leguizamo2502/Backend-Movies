using AppMovil.Models.Implements.Actor;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.Services.Http;
using AppMovil.Services.Implementations.Generic;

namespace AppMovil.Services.Implementations.Implements
{
    public class ActorService : GenericService<ActorSelectDto, ActorCreateDto, ActorUpdateDto>, IActorService
    {
        public ActorService(ApiClient api) : base(api, "Actor")
        {
        }
    }
}
