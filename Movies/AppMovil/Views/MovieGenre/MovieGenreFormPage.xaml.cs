using System.Collections.Generic;
using AppMovil.ViewModels.Implements.MovieGenre;
using Microsoft.Maui.Controls;

namespace AppMovil.Views.MovieGenre;

public partial class MovieGenreFormPage : ContentPage, IQueryAttributable
{
    public MovieGenreFormPage(MovieGenreFormViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (BindingContext is MovieGenreFormViewModel vm)
        {
            vm.ApplyQueryAttributes(query);
        }
    }
}
