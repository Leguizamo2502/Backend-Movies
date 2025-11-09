using System;
using System.IO;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Entity.DTOs.Auth;
using Entity.DTOs.Catalog.Movie.Select;
using FrontMovil.Config;
using FrontMovil.Core.Core.Abtractions;
using FrontMovil.Core.Models;
using Microsoft.Extensions.Logging;

namespace FrontMovil.Services.Api;

public class ApiClient : IApiClient
{
    private readonly HttpClient _httpClient;
    private readonly IAuthStorage _authStorage;
    private readonly ILogger<ApiClient> _logger;
    private readonly JsonSerializerOptions _jsonOptions;

    public ApiClient(HttpClient httpClient, IAuthStorage authStorage, ILogger<ApiClient> logger)
    {
        _httpClient = httpClient;
        _authStorage = authStorage;
        _logger = logger;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<ApiResult<bool>> LoginAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        try
        {
            var payload = new LoginUserDto
            {
                Email = email,
                Password = password
            };

            var response = await _httpClient.PostAsJsonAsync(ApiConstants.LoginEndpoint, payload, cancellationToken);
            var message = await ReadMessageAsync(response, cancellationToken) ?? "Inicio de sesión exitoso.";

            if (!response.IsSuccessStatusCode)
            {
                return ApiResult<bool>.Failure(message ?? "No se pudo iniciar sesión.");
            }

            await PersistTokensAsync(response);
            return ApiResult<bool>.Success(true, message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error durante el proceso de login");
            return ApiResult<bool>.Failure("Ocurrió un error inesperado al iniciar sesión.");
        }
    }

    public async Task<ApiResult<bool>> LogoutAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _httpClient.PostAsync(ApiConstants.LogoutEndpoint, null, cancellationToken);
            var message = await ReadMessageAsync(response, cancellationToken) ?? "Sesión cerrada.";

            await _authStorage.ClearAsync();

            if (!response.IsSuccessStatusCode)
            {
                return ApiResult<bool>.Failure(message ?? "No se pudo cerrar la sesión.");
            }

            return ApiResult<bool>.Success(true, message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error durante el cierre de sesión");
            return ApiResult<bool>.Failure("Ocurrió un error al cerrar sesión.");
        }
    }

    public async Task<ApiResult<IReadOnlyList<MovieSelectDto>>> GetMoviesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _httpClient.GetAsync(ApiConstants.MoviesEndpoint, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var movies = await response.Content.ReadFromJsonAsync<List<MovieSelectDto>>(_jsonOptions, cancellationToken) ??
                             new List<MovieSelectDto>();
                return ApiResult<IReadOnlyList<MovieSelectDto>>.Success(movies, $"{movies.Count} películas encontradas");
            }

            var message = await ReadMessageAsync(response, cancellationToken) ?? "No se pudieron cargar las películas.";
            return ApiResult<IReadOnlyList<MovieSelectDto>>.Failure(message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error obteniendo las películas");
            return ApiResult<IReadOnlyList<MovieSelectDto>>.Failure("No se pudieron cargar las películas.");
        }
    }

    private async Task PersistTokensAsync(HttpResponseMessage response)
    {
        try
        {
            if (response.Headers.TryGetValues("Set-Cookie", out var cookieHeaders))
            {
                string? accessToken = null;
                string? refreshToken = null;
                string? csrfToken = null;

                foreach (var header in cookieHeaders)
                {
                    foreach (var segment in header.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                    {
                        if (segment.StartsWith($"{ApiConstants.AccessTokenCookieName}=", StringComparison.OrdinalIgnoreCase))
                        {
                            accessToken = ExtractCookieValue(segment);
                        }
                        else if (segment.StartsWith($"{ApiConstants.RefreshTokenCookieName}=", StringComparison.OrdinalIgnoreCase))
                        {
                            refreshToken = ExtractCookieValue(segment);
                        }
                        else if (segment.StartsWith($"{ApiConstants.CsrfCookieName}=", StringComparison.OrdinalIgnoreCase))
                        {
                            csrfToken = ExtractCookieValue(segment);
                        }
                    }
                }

                await _authStorage.ClearAsync();
                await _authStorage.SaveTokensAsync(accessToken, refreshToken, csrfToken);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "No fue posible almacenar los tokens devueltos por la API");
        }
    }

    private static string? ExtractCookieValue(string segment)
    {
        var equalsIndex = segment.IndexOf('=');
        if (equalsIndex < 0 || equalsIndex == segment.Length - 1)
        {
            return null;
        }

        var value = segment[(equalsIndex + 1)..];
        return WebUtility.UrlDecode(value);
    }

    private async Task<string?> ReadMessageAsync(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        try
        {
            if (response.Content.Headers.ContentLength == 0)
            {
                return null;
            }

            var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
            if (stream == Stream.Null)
            {
                return null;
            }

            using var document = await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken);
            if (document.RootElement.TryGetProperty("message", out var messageProperty))
            {
                return messageProperty.GetString();
            }
        }
        catch (Exception ex)
        {
            _logger.LogDebug(ex, "No se pudo leer el mensaje de la respuesta");
        }

        return null;
    }
}
