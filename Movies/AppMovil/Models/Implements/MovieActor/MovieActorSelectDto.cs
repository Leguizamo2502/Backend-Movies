using AppMovil.Models.Base;

namespace AppMovil.Models.Implements.MovieActor;

public sealed class MovieActorSelectDto : BaseDto
{
    public int MovieId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int ActorId { get; set; }
    public string ActorName { get; set; } = string.Empty;
    public string? RoleName { get; set; }
}
