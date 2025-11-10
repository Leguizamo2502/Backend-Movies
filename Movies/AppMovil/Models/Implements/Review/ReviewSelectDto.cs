using AppMovil.Models.Base;

namespace AppMovil.Models.Implements.Review;

public sealed class ReviewSelectDto : BaseDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public int MovieId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string? Comment { get; set; }
}
