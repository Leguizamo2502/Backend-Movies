using Data.Interfaces.Implements.Catalog;
using Data.Repository;
using Entity.Domain.Models.Implements.Catalog;
using Entity.Infrastructure.Contexs;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Catalog
{
    public class MovieGenreRepository : DataGeneric<MovieGenre>, IMovieGenreRepository
    {
        public MovieGenreRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<MovieGenre>> GetAllAsync()
        {
            return await _dbSet
                .Include(mg => mg.Movie)
                .Include(mg => mg.Genre)
                .Where(mg => mg.IsDeleted == false)
                .ToListAsync();
        }

        public override async Task<MovieGenre?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(mg => mg.Movie)
                .Include(mg => mg.Genre)
                .FirstOrDefaultAsync(mg => mg.Id == id && mg.IsDeleted == false);
        }

    }
    
}
