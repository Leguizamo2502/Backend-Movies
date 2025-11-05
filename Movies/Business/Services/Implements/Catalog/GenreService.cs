using Business.Interfaces.Implements.Catalog;
using Business.Services.BaseService;
using Data.Interfaces.DataGeneric;
using Entity.Domain.Models.Implements.Catalog;
using Entity.DTOs.Catalog.Genre.Create;
using Entity.DTOs.Catalog.Genre.Select;
using Entity.DTOs.Catalog.Genre.Update;
using MapsterMapper;

namespace Business.Services.Implements.Catalog
{
    public class GenreService : BaseBusiness<Genre, GenreSelectDto, GenreCreateDto, GenreUpdateDto>, IGenreService
    {
        public GenreService(IMapper mapper, IDataGeneric<Genre> data) : base(mapper, data)
        {
        }
    }
}
