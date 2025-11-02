using Data.Interfaces.Implements.Catalog;
using Data.Repository;
using Entity.Domain.Models.Implements.Catalog;
using Entity.Infrastructure.Contexs;

namespace Data.Services.Catalog
{
    public class GenreRepository : DataGeneric<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
