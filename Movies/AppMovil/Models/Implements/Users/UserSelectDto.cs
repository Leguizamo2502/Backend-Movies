using AppMovil.Models.Base;

namespace AppMovil.Models.Implements.Users
{
    public class UserSelectDto : BaseDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
