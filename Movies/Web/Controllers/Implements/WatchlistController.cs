using Business.Interfaces.Implements.Talent;
using Business.Interfaces.Implements.Watchlists;
using Entity.Domain.Enums;
using Entity.DTOs.Watchlists.Create;
using Entity.DTOs.Watchlists.Select;
using Entity.DTOs.Watchlists.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Implements
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    public class WatchlistController : BaseController<WatchlistSelectDto, WatchlistCreateDto, WatchlistUpdateDto, IWacthlistService>
    {
        public WatchlistController(IWacthlistService service, ILogger<WatchlistController> logger) : base(service, logger)
        {
        }

        protected override Task AddAsync(WatchlistCreateDto dto)
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

        protected override async Task<IEnumerable<WatchlistSelectDto>> GetAllAsync(GetAllType getAllType)
        {
            var entity = await _service.GetAllAsync();
            if (entity is null) return null;


            return entity;
        }

        protected override Task<WatchlistSelectDto?> GetByIdAsync(int id)
        {
            return _service.GetByIdAsync(id);
        }

        protected override Task<bool> RestaureAsync(int id)
        {
            return _service.RestoreLogical(id);
        }

        protected override Task<bool> UpdateAsync(int id, WatchlistUpdateDto dto)
        {
            return _service.UpdateAsync(dto);

        }


    }
}
