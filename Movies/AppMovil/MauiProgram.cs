
using AppMovil.Config;
using AppMovil.Services.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net;

namespace AppMovil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // 1) Config de API
            var apiOptions = new ApiOptions
            {
                BaseUrl = "https://pottiest-administrative-madaline.ngrok-free.dev/api/v1/" // ← cámbiala a la real
            };
            builder.Services.AddSingleton(apiOptions);

            // 2) HttpClient central con soporte de cookies
            builder.Services.AddSingleton(new CookieContainer());
            builder.Services
                .AddHttpClient<ApiClient>()
                .ConfigurePrimaryHttpMessageHandler(sp => new HttpClientHandler
                {
                    CookieContainer = sp.GetRequiredService<CookieContainer>(),
                    UseCookies = true
                });


            //services
            builder.Services.AddServicesMaui();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
