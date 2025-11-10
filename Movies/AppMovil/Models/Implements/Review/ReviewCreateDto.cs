namespace AppMovil.Models.Implements.Review;

public sealed class ReviewCreateDto
{
    public int UserId { get; set; }
    public int MovieId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
}
