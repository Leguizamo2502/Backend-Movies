using Entity.Domain.Models.Base;
using Entity.Domain.Models.Implements.Reviews;
using Entity.Domain.Models.Implements.Watchlists;


namespace Entity.Domain.Models.Implements.Auth
{
    public class User : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public ICollection<Review> Reviews { get; set; } = [];
        public ICollection<Watchlist> Watchlists { get; set; }

    }
}
