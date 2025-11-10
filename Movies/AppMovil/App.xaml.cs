namespace AppMovil
{
    public partial class App : Application
    {
        public App(Views.Auth.LoginPage loginPage)
        {
            InitializeComponent();
            MainPage = loginPage;
        }
    }
}