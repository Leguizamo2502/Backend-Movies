using Business.Interfaces.Implements.Catalog;
using Entity.Domain.Enums;
using Entity.DTOs.Catalog.Movie.Create;
using Entity.DTOs.Catalog.Movie.Select;
using Entity.DTOs.Catalog.Movie.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Implements
{
    [Route("api/v1/[controller]")]
    //[Authorize]
    [ApiController]
    [Produces("application/json")]
    public class MovieController : BaseController<MovieSelectDto, MovieCreateDto, MovieUpdateDto, IMovieService>
    {
        public MovieController(IMovieService service, ILogger<MovieController> logger) : base(service, logger)
        {
        }

        protected override Task AddAsync(MovieCreateDto dto)
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

        protected override async Task<IEnumerable<MovieSelectDto>> GetAllAsync(GetAllType getAllType)
        {
            var entity = await _service.GetAllAsync(getAllType);
            if (entity is null) return null;


            return entity;
        }

        protected override Task<MovieSelectDto?> GetByIdAsync(int id)
        {
            return _service.GetByIdAsync(id);
        }

        protected override Task<bool> RestaureAsync(int id)
        {
            return _service.RestoreLogical(id);
        }

        protected override Task<bool> UpdateAsync(int id, MovieUpdateDto dto)
        {
            return _service.UpdateAsync(dto);

        }


    }
}
