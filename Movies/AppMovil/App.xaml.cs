using System;
using Microsoft.Maui.Controls;

namespace AppMovil
{
    public partial class App : Application
    {
        public App(Func<Views.Auth.LoginPage> loginPageFactory)
        {
            InitializeComponent();
            MainPage = loginPageFactory();
        }
    }
}
