using Entity.Domain.Models.Base;
using Entity.Domain.Models.Implements.Auth;
using Entity.Domain.Models.Implements.Catalog;

namespace Entity.Domain.Models.Implements.Reviews
{
    public class Review : BaseModel
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }   
        public string? Comment { get; set; }

        public User User { get; set; } = null!;
        public Movie Movie { get; set; } = null!;
    }
}
