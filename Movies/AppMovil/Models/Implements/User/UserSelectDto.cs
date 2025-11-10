using AppMovil.Models.Base;

namespace AppMovil.Models.Implements.User;

public sealed class UserSelectDto : BaseDto
{
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}
