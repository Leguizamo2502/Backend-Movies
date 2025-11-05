using Business.Interfaces.Implements.Catalog;
using Business.Services.BaseService;
using Data.Interfaces.DataGeneric;
using Entity.Domain.Models.Implements.Catalog;
using Entity.DTOs.Catalog.Movie.Create;
using Entity.DTOs.Catalog.Movie.Select;
using Entity.DTOs.Catalog.Movie.Update;
using MapsterMapper;

namespace Business.Services.Implements.Catalog
{
    public class MovieService : BaseBusiness<Movie, MovieSelectDto, MovieCreateDto, MovieUpdateDto>, IMovieService
    {
        public MovieService(IMapper mapper, IDataGeneric<Movie> data) : base(mapper, data)
        {
        }
    }
}
