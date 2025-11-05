using Entity.DTOs.Base;

namespace Entity.DTOs.Reviews.Update
{
    public class ReviewUpdateDto : BaseDto
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
