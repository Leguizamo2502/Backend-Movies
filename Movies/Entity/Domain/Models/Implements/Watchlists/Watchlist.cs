using Entity.Domain.Models.Base;
using Entity.Domain.Models.Implements.Auth;
using Entity.Domain.Models.Implements.Catalog;

namespace Entity.Domain.Models.Implements.Watchlists
{
    public class Watchlist : BaseModel
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }

        public User User { get; set; } = null!;
        public Movie Movie { get; set; } = null!;
    }
}
