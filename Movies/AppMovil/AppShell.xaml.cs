using AppMovil.Views.Actor;
using AppMovil.Views.Genre;
using AppMovil.Views.Users;

namespace AppMovil
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("actor/form", typeof(ActorFormPage));

            Routing.RegisterRoute("genre/form", typeof(GenreFormPage));
            
            Routing.RegisterRoute("user/form", typeof(UserFormPage));



        }
    }
}
