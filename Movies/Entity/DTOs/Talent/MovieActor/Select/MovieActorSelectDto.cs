using Entity.DTOs.Base;

namespace Entity.DTOs.Talent.MovieActor.Select
{
    public class MovieActorSelectDto : BaseDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string? RoleName { get; set; }
    }
}
