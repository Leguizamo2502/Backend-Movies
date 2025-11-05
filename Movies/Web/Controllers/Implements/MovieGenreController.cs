using Business.Interfaces.Implements.Catalog;
using Entity.Domain.Enums;
using Entity.DTOs.Catalog.MovieGenre.Create;
using Entity.DTOs.Catalog.MovieGenre.Select;
using Entity.DTOs.Catalog.MovieGenre.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Implements
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    public class MovieGenreController : BaseController<MovieGenreSelectDto, MovieGenreCreateDto, MovieGenreUpdateDto, IMovieGenreService>
    {
        public MovieGenreController(IMovieGenreService service, ILogger<MovieGenreController> logger) : base(service, logger)
        {
        }

        protected override Task AddAsync(MovieGenreCreateDto dto)
        {
            return _service.CreateAsync(dto);
        }

        protected override async Task<bool> DeleteAsync(int id, DeleteType deleteType)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity is null) return false;

            await _service.DeleteAsync(id, deleteType);
            return true;
        }

        protected override async Task<IEnumerable<MovieGenreSelectDto>> GetAllAsync(GetAllType getAllType)
        {
            var entity = await _service.GetAllAsync();
            if (entity is null) return null;


            return entity;
        }

        protected override Task<MovieGenreSelectDto?> GetByIdAsync(int id)
        {
            return _service.GetByIdAsync(id);
        }

        protected override Task<bool> RestaureAsync(int id)
        {
            return _service.RestoreLogical(id);
        }

        protected override Task<bool> UpdateAsync(int id, MovieGenreUpdateDto dto)
        {
            return _service.UpdateAsync(dto);

        }
    }
}
