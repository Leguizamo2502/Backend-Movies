using Business.Interfaces.Implements.Reviews;
using Entity.Domain.Enums;
using Entity.DTOs.Reviews.Create;
using Entity.DTOs.Reviews.Select;
using Entity.DTOs.Reviews.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Implements
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    public class ReviewController : BaseController<ReviewSelectDto, ReviewCreateDto, ReviewUpdateDto, IReviewService>
    {
        public ReviewController(IReviewService service, ILogger<ReviewController> logger) : base(service, logger)
        {
        }

        protected override Task AddAsync(ReviewCreateDto dto)
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

        protected override async Task<IEnumerable<ReviewSelectDto>> GetAllAsync(GetAllType getAllType)
        {
            var entity = await _service.GetAllAsync();
            if (entity is null) return null;


            return entity;
        }

        protected override Task<ReviewSelectDto?> GetByIdAsync(int id)
        {
            return _service.GetByIdAsync(id);
        }

        protected override Task<bool> RestaureAsync(int id)
        {
            return _service.RestoreLogical(id);
        }

        protected override Task<bool> UpdateAsync(int id, ReviewUpdateDto dto)
        {
            return _service.UpdateAsync(dto);

        }


    }
}
