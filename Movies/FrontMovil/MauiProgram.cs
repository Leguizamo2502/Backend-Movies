using System;
using System.Net;
using System.Net.Http;
using FrontMovil.Config;
using FrontMovil.Core.Core.Abtractions;
using FrontMovil.Services.Api;
using FrontMovil.Services.Auth;
using FrontMovil.Services.Handlers;
using FrontMovil.ViewModels.Auth;
using FrontMovil.ViewModels.Movies;
using FrontMovil.Views.Auth;
using FrontMovil.Views.Movies;
using Microsoft.Extensions.Logging;

namespace FrontMovil
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

            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<IAuthStorage, AuthStorage>();
            builder.Services.AddSingleton<AuthorizationMessageHandler>();

            builder.Services
                .AddHttpClient<IApiClient, ApiClient>(client =>
                {
                    client.BaseAddress = new Uri(ApiConstants.BaseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                })
                .AddHttpMessageHandler<AuthorizationMessageHandler>()
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    CookieContainer = new CookieContainer(),
                    UseCookies = true,
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                });

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<MovieListViewModel>();

            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<MovieListPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
