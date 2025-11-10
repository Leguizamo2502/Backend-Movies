using AppMovil.Services.Abstractions;
using AppMovil.Services.Abstractions.Generic;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.Services.Implementations;
using AppMovil.Services.Implementations.Generic;
using AppMovil.Services.Implementations.Implements;
using AppMovil.ViewModels.Implements.Actor;
using AppMovil.ViewModels.Movies;
using AppMovil.Views.Actor;
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

            // ----------------- Views / Pages ---------------------------
            services.AddTransient<MovieListPage>();
            services.AddTransient<ActorListPage>();   
            services.AddTransient<ActorFormPage>();    

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IActorService, ActorService>();

            return services;
        }
    }
}
