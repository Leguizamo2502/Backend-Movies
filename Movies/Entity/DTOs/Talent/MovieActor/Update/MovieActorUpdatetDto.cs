using Entity.DTOs.Base;

namespace Entity.DTOs.Talent.MovieActor.Update
{
    public class MovieActorUpdatetDto : BaseDto
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public string? RoleName { get; set; }
    }
}
