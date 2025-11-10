using AppMovil.ViewModels.Implements.Watchlist;
using Microsoft.Maui.Controls;

namespace AppMovil.Views.Watchlist;

public partial class WatchlistListPage : ContentPage
{
    private readonly WatchlistListViewModel _vm;

    public WatchlistListPage(WatchlistListViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_vm.Items.Count == 0)
        {
            await _vm.LoadCommand.ExecuteAsync(null);
        }
    }
}
