using Data.Interfaces.Implements.Watchlists;
using Data.Repository;
using Entity.Domain.Models.Implements.Watchlists;
using Entity.Infrastructure.Contexs;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Watchlists
{
    public class WatchlistRepository : DataGeneric<Watchlist>, IWatchlistRepository
    {
        public WatchlistRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Watchlist>> GetAllAsync()
        {
            return await _dbSet
                .Include(w => w.User)
                .Include(w => w.Movie)
                .Where(w => !w.IsDeleted)
                .ToListAsync();
        }

        public override async Task<Watchlist?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(w => w.User)
                .Include(w => w.Movie)
                .FirstOrDefaultAsync(w => w.Id == id && !w.IsDeleted);
        }
    }
}
