using Data.Interfaces.Implements.Watchlists;
using Data.Repository;
using Entity.Domain.Models.Implements.Watchlists;
using Entity.Infrastructure.Contexs;

namespace Data.Services.Watchlists
{
    public class WatchlistRepository : DataGeneric<Watchlist>, IWatchlistRepository
    {
        public WatchlistRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
