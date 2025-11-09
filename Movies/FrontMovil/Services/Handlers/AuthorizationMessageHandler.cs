using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using FrontMovil.Core.Core.Abtractions;

namespace FrontMovil.Services.Handlers;

public class AuthorizationMessageHandler : DelegatingHandler
{
    private readonly IAuthStorage _authStorage;

    public AuthorizationMessageHandler(IAuthStorage authStorage)
    {
        _authStorage = authStorage;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var accessToken = await _authStorage.GetAccessTokenAsync();
        if (!string.IsNullOrWhiteSpace(accessToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        if (RequiresCsrfHeader(request.Method))
        {
            var csrfToken = await _authStorage.GetCsrfTokenAsync();
            if (!string.IsNullOrWhiteSpace(csrfToken))
            {
                request.Headers.Remove("X-XSRF-TOKEN");
                request.Headers.Add("X-XSRF-TOKEN", csrfToken);
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }

    private static bool RequiresCsrfHeader(HttpMethod method) =>
        method != HttpMethod.Get &&
        method != HttpMethod.Head &&
        method != HttpMethod.Options;
}
