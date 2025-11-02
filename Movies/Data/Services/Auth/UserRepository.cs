using Data.Interfaces.Implements.Auth;
using Data.Repository;
using Entity.Domain.Models.Implements.Auth;
using Entity.DTOs.Auth;
using Entity.Infrastructure.Contexs;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Auth
{
    public class UserRepository : DataGeneric<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _dbSet.AnyAsync(u=>u.Email == email);
        }

        public async Task<User?> FindEmail(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u=>u.Email == email);
        }

        public async Task<User> LoginUser(LoginUserDto loginDto)
        {
            bool suceeded = false;

            var user = await _dbSet
                .FirstOrDefaultAsync(u =>
                            u.Email == loginDto.Email &&
                            u.Password == loginDto.Password);

            suceeded = user != null ? true : throw new UnauthorizedAccessException("Credenciales inválidas");

            return user;
        }
    }
}
