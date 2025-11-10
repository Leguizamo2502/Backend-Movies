using AppMovil.Views.Actor;
using AppMovil.Views.Genre;

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
