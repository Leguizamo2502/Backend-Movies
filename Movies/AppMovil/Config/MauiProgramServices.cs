using AppMovil.Models.Implements.Actor;
using AppMovil.Services.Abstractions;
using AppMovil.Services.Abstractions.Generic;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.Services.Http;
using AppMovil.Services.Implementations;
using AppMovil.Services.Implementations.Generic;
using AppMovil.Services.Implementations.Implements;
using AppMovil.ViewModels.Implements.Actor;
using AppMovil.ViewModels.Implements.Genre;
using AppMovil.ViewModels.Implements.MovieActor;
using AppMovil.ViewModels.Implements.MovieGenre;
using AppMovil.ViewModels.Implements.Review;
using AppMovil.ViewModels.Implements.Watchlist;
using AppMovil.ViewModels.Movies;
using AppMovil.Views.Actor;
using AppMovil.Views.Genre;
using AppMovil.Views.MovieActor;
using AppMovil.Views.MovieGenre;
using AppMovil.Views.Movies;

namespace AppMovil.Config
{
    public static class MauiProgramServices
    {
        public static IServiceCollection AddServicesMaui(this IServiceCollection services)
        {
            //Generic Service
            services.AddScoped(typeof(IGenericService<,,>), typeof(GenericService<,,>));



            // ----------------- ViewModels -------------------------------
            services.AddScoped<MovieListViewModel>();

            services.AddScoped<ActorListViewModel>();
            services.AddScoped<ActorFormViewModel>();

            services.AddScoped<GenreListViewModel>();
            services.AddScoped<GenreFormViewModel>();

            // ----------------- Views / Pages ---------------------------
            services.AddTransient<MovieListPage>();

            services.AddTransient<ActorListPage>();
            services.AddTransient<ActorFormPage>();

            services.AddTransient<GenreListPage>();
            services.AddTransient<GenreFormPage>();



            //services
            services.AddScoped<IMovieService, MovieService>();

            services.AddScoped<IActorService, ActorService>();

            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IMovieActorService, MovieActorService>();
            services.AddScoped<IMovieGenreService, MovieGenreService>();
            services.AddScoped<IWatchlistService, WatchlistService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IUserLookupService, UserLookupService>();

            services.AddScoped<IUserService, UserServices>();

            return services;
        }
    }
}
