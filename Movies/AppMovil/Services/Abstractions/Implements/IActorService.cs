using AppMovil.Models.Implements.Actor;
using AppMovil.Services.Abstractions.Generic;

namespace AppMovil.Services.Abstractions.Implements
{
    public interface IActorService : IGenericService<ActorSelectDto, ActorCreateDto, ActorUpdateDto>
    {
    }
}
