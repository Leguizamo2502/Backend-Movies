using AppMovil.Models.Base;

namespace AppMovil.Models.Implements.Actor
{
    public class ActorUpdateDto : BaseDto
    {
        public string Name { get; set; } 
        public int? BirthYear { get; set; }
    }
}
