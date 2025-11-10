using AppMovil.Models.Implements.Auth;
using AppMovil.Services.Abstractions;
using AppMovil.Services.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace AppMovil.Services.Implementations;

public sealed class AuthService : IAuthService
{
    private readonly ApiClient _apiClient;

    public AuthService(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request, CancellationToken ct = default)
    {
        try
        {
            var httpResponse = await _apiClient.PostRawAsync("Auth/Login", request, ct);

            LoginResponseDto? payload = null;
            try
            {
                payload = await httpResponse.Content.ReadFromJsonAsync<LoginResponseDto>(cancellationToken: ct);
            }
            catch (NotSupportedException)
            {
            }
            catch (JsonException)
            {
            }

            if (payload is null)
            {
                payload = new LoginResponseDto
                {
                    IsSuccess = httpResponse.IsSuccessStatusCode,
                    Message = httpResponse.IsSuccessStatusCode
                        ? "Inicio de sesión completado."
                        : "No se pudo iniciar sesión."
                };
            }
            else
            {
                payload.IsSuccess = httpResponse.IsSuccessStatusCode && payload.IsSuccess;
            }

            return payload;
        }
        catch (HttpRequestException ex)
        {
            throw new InvalidOperationException("No se pudo conectar con el servidor. Inténtalo nuevamente.", ex);
        }
    }
}
