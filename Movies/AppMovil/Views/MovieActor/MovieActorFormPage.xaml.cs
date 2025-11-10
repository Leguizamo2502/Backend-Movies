using System.Collections.Generic;
using AppMovil.ViewModels.Implements.MovieActor;
using Microsoft.Maui.Controls;

namespace AppMovil.Views.MovieActor;

public partial class MovieActorFormPage : ContentPage, IQueryAttributable
{
    public MovieActorFormPage(MovieActorFormViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (BindingContext is MovieActorFormViewModel vm)
        {
            vm.ApplyQueryAttributes(query);
        }
    }
}
