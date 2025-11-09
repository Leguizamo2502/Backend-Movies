using FrontMovil.ViewModels.Movies;

namespace FrontMovil.Views.Movies;

public partial class MovieListPage : ContentPage
{
    private readonly MovieListViewModel _viewModel;

    public MovieListPage(MovieListViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();
    }
}
