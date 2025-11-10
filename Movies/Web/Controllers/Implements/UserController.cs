using Business.Interfaces.Implements.Auth;
using Business.Interfaces.Implements.Talent;
using Entity.Domain.Enums;
using Entity.DTOs.Auth.User.Create;
using Entity.DTOs.Auth.User.Select;
using Entity.DTOs.Auth.User.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Implements
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    public class UserController : BaseController<UserSelectDto, UserCreateDto, UserUpdateDto, IUserService>
    {
        public UserController(IUserService service, ILogger<UserController> logger) : base(service, logger)
        {
        }

        protected override Task AddAsync(UserCreateDto dto)
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

        protected override async Task<IEnumerable<UserSelectDto>> GetAllAsync(GetAllType getAllType)
        {
            var entity = await _service.GetAllAsync(getAllType);
            if (entity is null) return null;


            return entity;
        }

        protected override Task<UserSelectDto?> GetByIdAsync(int id)
        {
            return _service.GetByIdAsync(id);
        }

        protected override Task<bool> RestaureAsync(int id)
        {
            return _service.RestoreLogical(id);
        }

        protected override Task<bool> UpdateAsync(int id, UserUpdateDto dto)
        {
            return _service.UpdateAsync(dto);

        }

        
    }
}
