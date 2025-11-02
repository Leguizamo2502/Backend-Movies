using Data.Interfaces.Implements.Catalog;
using Data.Repository;
using Entity.Domain.Models.Implements.Catalog;
using Entity.Infrastructure.Contexs;

namespace Data.Services.Catalog
{
    public class MovieRepository : DataGeneric<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
