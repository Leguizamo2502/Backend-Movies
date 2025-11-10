using AppMovil.Models.Implements.Actor;
using AppMovil.Services.Abstractions.Generic;
using AppMovil.ViewModels.Generic;

namespace AppMovil.ViewModels.Implements.Actor
{
    public sealed class ActorListViewModel : BaseListViewModel<ActorSelectDto>
    {
        public ActorListViewModel(IGenericService<ActorSelectDto, object, object> service) : base(service)
        {
            Title = "Actores";
        }
    }
}
