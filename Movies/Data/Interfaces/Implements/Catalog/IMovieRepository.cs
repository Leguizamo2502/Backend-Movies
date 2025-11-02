using Data.Interfaces.DataGeneric;
using Entity.Domain.Models.Implements.Catalog;

namespace Data.Interfaces.Implements.Catalog
{
    public interface IMovieRepository : IDataGeneric<Movie>
    {
    }
}
