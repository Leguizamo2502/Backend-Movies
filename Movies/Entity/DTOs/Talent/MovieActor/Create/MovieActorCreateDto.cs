namespace Entity.DTOs.Talent.MovieActor.Create
{
    public class MovieActorCreateDto
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public string? RoleName { get; set; }
    }
}
