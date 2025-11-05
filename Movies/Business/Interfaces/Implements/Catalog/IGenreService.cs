using Business.Interfaces.BaseService;
using Entity.DTOs.Catalog.Genre.Create;
using Entity.DTOs.Catalog.Genre.Select;
using Entity.DTOs.Catalog.Genre.Update;

namespace Business.Interfaces.Implements.Catalog
{
    public interface IGenreService : IBaseBusiness<GenreSelectDto, GenreCreateDto, GenreUpdateDto>
    {
    }
}
