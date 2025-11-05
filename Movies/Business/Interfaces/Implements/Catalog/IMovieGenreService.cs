using Business.Interfaces.BaseService;
using Entity.DTOs.Catalog.MovieGenre.Create;
using Entity.DTOs.Catalog.MovieGenre.Select;
using Entity.DTOs.Catalog.MovieGenre.Update;

namespace Business.Interfaces.Implements.Catalog
{
    public interface IMovieGenreService : IBaseBusiness<MovieGenreSelectDto, MovieGenreCreateDto, MovieGenreUpdateDto>
    {
    }
}
