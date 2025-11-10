using AppMovil.Services.Abstractions;
using AppMovil.Services.Abstractions.Generic;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.Services.Implementations;
using AppMovil.Services.Implementations.Generic;
using AppMovil.Services.Implementations.Implements;
using AppMovil.ViewModels.Implements.Actor;
using AppMovil.ViewModels.Implements.Genre;
using AppMovil.ViewModels.Implements.MovieActor;
using AppMovil.ViewModels.Implements.MovieGenre;
using AppMovil.ViewModels.Implements.Movies;
using AppMovil.ViewModels.Implements.Review;
using AppMovil.ViewModels.Implements.Watchlist;
using AppMovil.Views.Actor;
using AppMovil.Views.Genre;
using AppMovil.Views.MovieActor;
using AppMovil.Views.MovieGenre;
using AppMovil.Views.Movies;
using AppMovil.Views.Review;
using AppMovil.Views.Watchlist;

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
            services.AddScoped<MovieFormViewModel>();

            services.AddScoped<ActorListViewModel>();
            services.AddScoped<ActorFormViewModel>();

            services.AddScoped<GenreListViewModel>();
            services.AddScoped<GenreFormViewModel>();

            services.AddScoped<MovieActorListViewModel>();
            services.AddScoped<MovieActorFormViewModel>();

            services.AddScoped<MovieGenreListViewModel>();
            services.AddScoped<MovieGenreFormViewModel>();

            services.AddScoped<WatchlistListViewModel>();
            services.AddScoped<WatchlistFormViewModel>();

            services.AddScoped<ReviewListViewModel>();
            services.AddScoped<ReviewFormViewModel>();

            // ----------------- Views / Pages ---------------------------
            services.AddTransient<MovieListPage>();
            services.AddTransient<MovieFormPage>(); 

            services.AddTransient<ActorListPage>();
            services.AddTransient<ActorFormPage>();

            services.AddTransient<GenreListPage>();
            services.AddTransient<GenreFormPage>();

            services.AddTransient<MovieActorListPage>();
            services.AddTransient<MovieActorFormPage>();

            services.AddTransient<MovieGenreListPage>();
            services.AddTransient<MovieGenreFormPage>();

            services.AddTransient<WatchlistListPage>();
            services.AddTransient<WatchlistFormPage>();

            services.AddTransient<ReviewListPage>();
            services.AddTransient<ReviewFormPage>();


            //services
            services.AddScoped<IMovieService, MovieService>();

            services.AddScoped<IActorService, ActorService>();

            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IMovieActorService, MovieActorService>();
            services.AddScoped<IMovieGenreService, MovieGenreService>();
            services.AddScoped<IWatchlistService, WatchlistService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IUserLookupService, UserLookupService>();

            return services;
        }
    }
}
