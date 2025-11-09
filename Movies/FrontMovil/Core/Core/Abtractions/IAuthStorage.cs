namespace FrontMovil.Core.Core.Abtractions;

public interface IAuthStorage
{
    Task SaveTokensAsync(string? accessToken, string? refreshToken, string? csrfToken);
    Task<string?> GetAccessTokenAsync();
    Task<string?> GetRefreshTokenAsync();
    Task<string?> GetCsrfTokenAsync();
    Task ClearAsync();
}
