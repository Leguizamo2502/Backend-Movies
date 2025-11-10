using AppMovil.Models.Base;

namespace AppMovil.Models.Implements.Reviews
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
