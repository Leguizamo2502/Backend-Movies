using AppMovil.Models.Implements.Auth;

namespace AppMovil.Services.Abstractions;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request, CancellationToken ct = default);
}
