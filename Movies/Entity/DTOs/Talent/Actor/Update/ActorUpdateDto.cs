using Entity.DTOs.Base;

namespace Entity.DTOs.Talent.Actor.Update
{
    public class ActorUpdateDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public int? BirthYear { get; set; }
    }
}
