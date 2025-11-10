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
using AppMovil.ViewModels.Implements.Users;
using AppMovil.ViewModels.Movies;
using AppMovil.Views.Actor;
using AppMovil.Views.Genre;
using AppMovil.Views.Movies;
using AppMovil.Views.Users;

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

            services.AddScoped<UserListViewModel>();
            services.AddScoped<UserFormViewModel>();

            // ----------------- Views / Pages ---------------------------
            services.AddTransient<MovieListPage>();

            services.AddTransient<ActorListPage>();   
            services.AddTransient<ActorFormPage>();  

            services.AddTransient<GenreListPage>();
            services.AddTransient<GenreFormPage>();

            services.AddTransient<UserListPage>();
            services.AddTransient<UserFormPage>();


            //services
            services.AddScoped<IMovieService, MovieService>();

            services.AddScoped<IActorService, ActorService>();

            services.AddScoped<IGenreService, GenreService>();

            services.AddScoped<IUserService, UserServices>();

            return services;
        }
    }
}
