using Data.Interfaces.Implements.Talent;
using Data.Repository;
using Entity.Domain.Models.Implements.Talent;
using Entity.Infrastructure.Contexs;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Talent
{
    public class MovieActorRepository : DataGeneric<MovieActor>, IMovieActorRepository
    {
        public MovieActorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<MovieActor>> GetAllAsync()
        {
            return await _dbSet
                .Include(ma => ma.Movie)
                .Include(ma => ma.Actor)
                .Where(ma => !ma.IsDeleted)
                .ToListAsync();
        }

        public override async Task<MovieActor?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(ma => ma.Movie)
                .Include(ma => ma.Actor)
                .FirstOrDefaultAsync(ma => ma.Id == id && !ma.IsDeleted);
        }

    }
}
