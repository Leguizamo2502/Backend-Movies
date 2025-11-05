using Entity.DTOs.Base;

namespace Entity.DTOs.Reviews.Select
{
    public class ReviewSelectDto : BaseDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
