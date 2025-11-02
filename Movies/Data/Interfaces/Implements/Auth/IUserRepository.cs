using Data.Interfaces.DataGeneric;
using Entity.Domain.Models.Implements.Auth;
using Entity.DTOs.Auth;

namespace Data.Interfaces.Implements.Auth
{
    public interface IUserRepository : IDataGeneric<User>
    {
        Task<bool> ExistsByEmailAsync(string email);
        Task<User?> FindEmail(string email);
        Task<User> LoginUser(LoginUserDto loginDto);
    }
}
