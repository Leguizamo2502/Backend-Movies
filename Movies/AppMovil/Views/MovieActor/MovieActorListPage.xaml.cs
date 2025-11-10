using AppMovil.ViewModels.Implements.MovieActor;
using Microsoft.Maui.Controls;

namespace AppMovil.Views.MovieActor;

public partial class MovieActorListPage : ContentPage
{
    private readonly MovieActorListViewModel _vm;

    public MovieActorListPage(MovieActorListViewModel vm)
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
