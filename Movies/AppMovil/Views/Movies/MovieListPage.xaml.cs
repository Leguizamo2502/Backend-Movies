using AppMovil.ViewModels.Implements.Movies;

namespace AppMovil.Views.Movies;

public partial class MovieListPage : ContentPage
{
    private readonly MovieListViewModel _vm;

    public MovieListPage(MovieListViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Si prefieres refrescar siempre, elimina el if
        if (_vm.Items.Count == 0)
            await _vm.LoadCommand.ExecuteAsync(null);
    }
}