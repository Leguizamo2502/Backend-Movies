using Entity.Domain.Models.Base;

namespace Entity.DTOs.Auth.User.Update
{
    public class UserUpdateDto : BaseModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
