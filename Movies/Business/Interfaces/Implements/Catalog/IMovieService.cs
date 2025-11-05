using Business.Interfaces.BaseService;
using Entity.DTOs.Catalog.Movie.Create;
using Entity.DTOs.Catalog.Movie.Select;
using Entity.DTOs.Catalog.Movie.Update;

namespace Business.Interfaces.Implements.Catalog
{
    public interface IMovieService : IBaseBusiness<MovieSelectDto, MovieCreateDto, MovieUpdateDto>
    {
    }
}
