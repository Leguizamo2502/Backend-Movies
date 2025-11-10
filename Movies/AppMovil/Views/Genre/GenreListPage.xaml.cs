using AppMovil.ViewModels.Implements.Genre;

namespace AppMovil.Views.Genre;

public partial class GenreListPage : ContentPage
{
	private readonly GenreListViewModel _vm;
	public GenreListPage(GenreListViewModel vm)
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