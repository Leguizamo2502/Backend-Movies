using Entity.DTOs.Base;

namespace Entity.DTOs.Auth.User.Select
{
    public class UserSelectDto : BaseDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
