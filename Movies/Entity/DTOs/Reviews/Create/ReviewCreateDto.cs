namespace Entity.DTOs.Reviews.Create
{
    public class ReviewCreateDto
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
