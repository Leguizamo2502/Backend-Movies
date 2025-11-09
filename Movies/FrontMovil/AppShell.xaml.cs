namespace FrontMovil
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("movies/form", typeof(Views.Movies.MovieFormPage));     // Create/Edit
        }
    }
}
