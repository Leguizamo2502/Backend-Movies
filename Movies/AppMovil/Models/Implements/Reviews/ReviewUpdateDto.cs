using AppMovil.Models.Base;

namespace AppMovil.Models.Implements.Reviews
{
    public class ReviewUpdateDto : BaseDto
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
