using AppMovil.ViewModels.Implements.Users;

namespace AppMovil.Views.Users;

public partial class UserListPage : ContentPage
{
	private readonly UserListViewModel _vm;
	public UserListPage(UserListViewModel vm)
	{
		InitializeComponent();
		BindingContext = _vm = vm;	
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_vm.Items.Count == 0)
            await _vm.LoadCommand.ExecuteAsync(null);
    }
}