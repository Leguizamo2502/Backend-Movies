using System.Collections.Generic;
using AppMovil.ViewModels.Implements.Watchlist;
using Microsoft.Maui.Controls;

namespace AppMovil.Views.Watchlist;

public partial class WatchlistFormPage : ContentPage, IQueryAttributable
{
    public WatchlistFormPage(WatchlistFormViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (BindingContext is WatchlistFormViewModel vm)
        {
            vm.ApplyQueryAttributes(query);
        }
    }
}
