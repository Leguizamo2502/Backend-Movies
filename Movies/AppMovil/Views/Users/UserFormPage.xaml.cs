using AppMovil.ViewModels.Implements.Users;

namespace AppMovil.Views.Users;

public partial class UserFormPage : ContentPage, IQueryAttributable
{
	public UserFormPage(UserFormViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (BindingContext is UserFormViewModel vm)
        {
            vm.ApplyQueryAttributes(query);
        }
    }
}