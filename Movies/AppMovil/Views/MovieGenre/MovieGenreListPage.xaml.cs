using AppMovil.ViewModels.Implements.MovieGenre;
using Microsoft.Maui.Controls;

namespace AppMovil.Views.MovieGenre;

public partial class MovieGenreListPage : ContentPage
{
    private readonly MovieGenreListViewModel _vm;

    public MovieGenreListPage(MovieGenreListViewModel vm)
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
