using AppMovil.Views.Actor;
using AppMovil.Views.Genre;
using AppMovil.Views.MovieActor;
using AppMovil.Views.MovieGenre;
using AppMovil.Views.Review;
using AppMovil.Views.Watchlist;

namespace AppMovil
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("actor/form", typeof(ActorFormPage));

            Routing.RegisterRoute("genre/form", typeof(GenreFormPage));


        }
    }
}
