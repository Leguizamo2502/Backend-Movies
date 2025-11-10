using AppMovil.Models.Implements.Users;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.Services.Http;
using AppMovil.Services.Implementations.Generic;

namespace AppMovil.Services.Implementations.Implements
{
    public class UserServices : GenericService<UserSelectDto, UserCreateDto, UserUpdateDto>, IUserService
    {
        public UserServices(ApiClient api) : base(api, "User")
        {
        }
    }
}
