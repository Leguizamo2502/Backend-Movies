using Entity.Domain.Models.Base;
using Entity.Domain.Models.Implements.Catalog;

namespace Entity.Domain.Models.Implements.Talent
{
    public class MovieActor : BaseModel
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public string? RoleName { get; set; }

        public Movie Movie { get; set; } = null!;
        public Actor Actor { get; set; } = null!;
    }
}
