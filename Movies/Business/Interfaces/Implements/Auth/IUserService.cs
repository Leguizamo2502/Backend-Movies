using Business.Interfaces.BaseService;
using Entity.DTOs.Auth.User.Create;
using Entity.DTOs.Auth.User.Select;
using Entity.DTOs.Auth.User.Update;

namespace Business.Interfaces.Implements.Auth
{
    public interface IUserService : IBaseBusiness<UserSelectDto,UserCreateDto,UserUpdateDto>
    {
    }
}
