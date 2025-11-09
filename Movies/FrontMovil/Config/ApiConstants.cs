using Microsoft.Maui.Devices;

namespace FrontMovil.Config;

public static class ApiConstants
{
    public const string AccessTokenCookieName = "access_token";
    public const string RefreshTokenCookieName = "refresh_token";
    public const string CsrfCookieName = "XSRF-TOKEN";

    private const string DefaultBaseUrl = "http://localhost:5029";
    private const string AndroidEmulatorBaseUrl = "http://10.0.2.2:5029";

    public static string BaseUrl => DeviceInfo.Platform switch
    {
        DevicePlatform.Android => AndroidEmulatorBaseUrl,
        DevicePlatform.WinUI => DefaultBaseUrl,
        DevicePlatform.MacCatalyst => DefaultBaseUrl,
        DevicePlatform.iOS => DefaultBaseUrl,
        _ => DefaultBaseUrl
    };

    public const string LoginEndpoint = "/api/v1/Auth/Login";
    public const string LogoutEndpoint = "/api/v1/Auth/logout";
    public const string MoviesEndpoint = "/api/v1/Movie";
}
