using AppMovil.Views.Actor;

namespace AppMovil
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("actor/form", typeof(ActorFormPage));

        }
    }
}
