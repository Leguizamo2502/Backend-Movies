using Entity.DTOs.Base;

namespace Entity.DTOs.Talent.MovieActor.Select
{
    public class MovieActorSelectDto : BaseDto
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public string? RoleName { get; set; }
    }
}
