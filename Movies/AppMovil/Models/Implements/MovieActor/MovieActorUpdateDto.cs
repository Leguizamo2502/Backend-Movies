using AppMovil.Models.Base;

namespace AppMovil.Models.Implements.MovieActor;

public sealed class MovieActorUpdateDto : BaseDto
{
    public int MovieId { get; set; }
    public int ActorId { get; set; }
    public string? RoleName { get; set; }
}
