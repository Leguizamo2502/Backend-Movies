using AppMovil.ViewModels.Movies;

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
        if (_vm.Items.Count == 0)
            await _vm.LoadAsyncCommand.ExecuteAsync(null);
    }
}