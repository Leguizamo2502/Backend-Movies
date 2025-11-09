using System.Threading.Tasks;
using FrontMovil.Core.Core.Abtractions;
using Microsoft.Maui.Storage;

namespace FrontMovil.Services.Auth;

public class AuthStorage : IAuthStorage
{
    private const string AccessTokenKey = "FrontMovil.AccessToken";
    private const string RefreshTokenKey = "FrontMovil.RefreshToken";
    private const string CsrfTokenKey = "FrontMovil.CsrfToken";

    public async Task SaveTokensAsync(string? accessToken, string? refreshToken, string? csrfToken)
    {
        if (!string.IsNullOrWhiteSpace(accessToken))
        {
            await SecureStorage.Default.SetAsync(AccessTokenKey, accessToken);
        }

        if (!string.IsNullOrWhiteSpace(refreshToken))
        {
            await SecureStorage.Default.SetAsync(RefreshTokenKey, refreshToken);
        }

        if (!string.IsNullOrWhiteSpace(csrfToken))
        {
            await SecureStorage.Default.SetAsync(CsrfTokenKey, csrfToken);
        }
    }

    public Task<string?> GetAccessTokenAsync() => SecureStorage.Default.GetAsync(AccessTokenKey);

    public Task<string?> GetRefreshTokenAsync() => SecureStorage.Default.GetAsync(RefreshTokenKey);

    public Task<string?> GetCsrfTokenAsync() => SecureStorage.Default.GetAsync(CsrfTokenKey);

    public Task ClearAsync()
    {
        SecureStorage.Default.Remove(AccessTokenKey);
        SecureStorage.Default.Remove(RefreshTokenKey);
        SecureStorage.Default.Remove(CsrfTokenKey);
        return Task.CompletedTask;
    }
}
