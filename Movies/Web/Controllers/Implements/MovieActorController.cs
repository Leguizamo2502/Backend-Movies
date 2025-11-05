using Business.Interfaces.Implements.Talent;
using Entity.Domain.Enums;
using Entity.DTOs.Talent.MovieActor.Create;
using Entity.DTOs.Talent.MovieActor.Select;
using Entity.DTOs.Talent.MovieActor.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Implements
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    public class MovieActorController : BaseController<MovieActorSelectDto, MovieActorCreateDto, MovieActorUpdatetDto, IMovieActorService>
    {
        public MovieActorController(IMovieActorService service, ILogger<MovieActorController> logger) : base(service, logger)
        {
        }

        protected override Task AddAsync(MovieActorCreateDto dto)
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

        protected override async Task<IEnumerable<MovieActorSelectDto>> GetAllAsync(GetAllType getAllType)
        {
            var entity = await _service.GetAllAsync();
            if (entity is null) return null;


            return entity;
        }

        protected override Task<MovieActorSelectDto?> GetByIdAsync(int id)
        {
            return _service.GetByIdAsync(id);
        }

        protected override Task<bool> RestaureAsync(int id)
        {
            return _service.RestoreLogical(id);
        }

        protected override Task<bool> UpdateAsync(int id, MovieActorUpdatetDto dto)
        {
            return _service.UpdateAsync(dto);

        }


    }
}
