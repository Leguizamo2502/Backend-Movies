namespace AppMovil.Models.Implements.MovieActor;

public sealed class MovieActorCreateDto
{
    public int MovieId { get; set; }
    public int ActorId { get; set; }
    public string? RoleName { get; set; }
}
