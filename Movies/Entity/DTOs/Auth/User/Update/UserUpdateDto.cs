using Entity.Domain.Models.Base;
using Entity.DTOs.Base;

namespace Entity.DTOs.Auth.User.Update
{
    public class UserUpdateDto : BaseDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
