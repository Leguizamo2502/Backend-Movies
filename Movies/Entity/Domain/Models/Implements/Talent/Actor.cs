using Entity.Domain.Models.Base;

namespace Entity.Domain.Models.Implements.Talent
{
    public class Actor : BaseModel
    {
        public string Name { get; set; } = null!;
        public int? BirthYear { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
