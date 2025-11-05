using Business.Interfaces.Implements.Auth;
using Business.Interfaces.Implements.Catalog;
using Business.Interfaces.Implements.Reviews;
using Business.Interfaces.Implements.Talent;
using Business.Interfaces.Implements.Watchlists;
using Business.Mapping;
using Business.Services.Implements.Auth;
using Business.Services.Implements.Auth.Users;
using Business.Services.Implements.Catalog;
using Business.Services.Implements.Catalog.Implements;
using Business.Services.Implements.Reviews;
using Business.Services.Implements.Talent;
using Business.Services.Implements.Watchlists;
using Data.Interfaces.DataGeneric;
using Data.Interfaces.Implements.Auth;
using Data.Interfaces.Implements.Catalog;
using Data.Interfaces.Implements.Reviews;
using Data.Interfaces.Implements.Talent;
using Data.Interfaces.Implements.Watchlists;
using Data.Repository;
using Data.Services.Auth;
using Data.Services.Catalog;
using Data.Services.Reviews;
using Data.Services.Talent;
using Data.Services.Watchlists;
using Mapster;
using Web.Infrastructure.Cookies.Implements;

namespace Web.ProgramService
{
    public static class ApplicationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            //Data Generica
            services.AddScoped(typeof(IDataGeneric<>), typeof(DataGeneric<>));

            //Mapping
            services.AddMapster();
            MapsterConfig.Register();

            //Jwt y cookies
            services.AddScoped<IToken, TokenBusiness>();
            services.AddScoped<IAuthCookieFactory, AuthCookieFactory>();

            //services
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();

            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IActorService, ActorService>();

            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IGenreService, GenreService>();

            services.AddScoped<IMovieGenreRepository, MovieGenreRepository>();
            services.AddScoped<IMovieGenreService, MovieGenreService>();

            services.AddScoped<IWatchlistRepository, WatchlistRepository>();
            services.AddScoped<IWacthlistService, WatchlistService>();

            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReviewService, ReviewService>();

            services.AddScoped<IMovieActorRepository, MovieActorRepository>();
            services.AddScoped<IMovieActorService, MovieActorService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();



            return services;
        }
    }
}
