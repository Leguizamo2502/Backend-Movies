using AppMovil.Models.Base;

namespace AppMovil.Models.Implements.Users
{
    public class UserUpdateDto : BaseDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
