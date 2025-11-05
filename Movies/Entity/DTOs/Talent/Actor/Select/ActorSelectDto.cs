using Entity.DTOs.Base;

namespace Entity.DTOs.Talent.Actor.Select
{
    public class ActorSelectDto : BaseDto
    {
        public string Name { get; set; }
        public int? BirthYear { get; set; }
    }
}
