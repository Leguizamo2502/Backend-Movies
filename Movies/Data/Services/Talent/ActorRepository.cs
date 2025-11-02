using Data.Interfaces.Implements.Talent;
using Data.Repository;
using Entity.Domain.Models.Implements.Talent;
using Entity.Infrastructure.Contexs;

namespace Data.Services.Talent
{
    public class ActorRepository : DataGeneric<Actor>, IActorRepository
    {
        public ActorRepository(ApplicationDbContext context) : base(context)
        {
        }   
    
    }
}
