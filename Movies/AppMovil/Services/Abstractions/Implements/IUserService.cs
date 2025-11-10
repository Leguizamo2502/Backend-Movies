using AppMovil.Models.Implements.Users;
using AppMovil.Services.Abstractions.Generic;

namespace AppMovil.Services.Abstractions.Implements
{
    public interface IUserService : IGenericService<UserSelectDto,UserCreateDto,UserUpdateDto>
    {
    }
}
