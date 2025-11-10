using AppMovil.Config;
using AppMovil.Services.Abstractions;
using AppMovil.Services.Http;
using AppMovil.Services.Implementations;
using AppMovil.ViewModels.Movies;
using AppMovil.Views.Movies;
using Microsoft.Extensions.Logging;

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

            // 2) HttpClient central
            builder.Services.AddHttpClient<ApiClient>();


            //services
            builder.Services.AddServicesMaui();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
