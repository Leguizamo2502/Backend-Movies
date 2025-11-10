using AppMovil.Views.Actor;
using AppMovil.Views.Genre;
using AppMovil.Views.MovieActor;
using AppMovil.Views.MovieGenre;
using AppMovil.Views.Movies;
using AppMovil.Views.Review;
using AppMovil.Views.Watchlist;

namespace AppMovil
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("movie/form", typeof(MovieFormPage));

            Routing.RegisterRoute("actor/form", typeof(ActorFormPage));

            Routing.RegisterRoute("genre/form", typeof(GenreFormPage));

            Routing.RegisterRoute("movieactor/form", typeof(MovieActorFormPage));
            Routing.RegisterRoute("moviegenre/form", typeof(MovieGenreFormPage));
            Routing.RegisterRoute("watchlist/form", typeof(WatchlistFormPage));
            Routing.RegisterRoute("review/form", typeof(ReviewFormPage));


        }
    }
}
