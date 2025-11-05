using Data.Interfaces.Implements.Reviews;
using Data.Repository;
using Entity.Domain.Models.Implements.Reviews;
using Entity.Infrastructure.Contexs;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Reviews
{
    public class ReviewRepository : DataGeneric<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _dbSet
                .Include(r => r.User)
                .Include(r => r.Movie)
                .Where(r => !r.IsDeleted)
                .ToListAsync();
        }
        public override async Task<Review?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(r => r.User)
                .Include(r => r.Movie)
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
        }

    }
}
