using AppMovil.ViewModels.Implements.Genre;

namespace AppMovil.Views.Genre;

public partial class GenreFormPage : ContentPage, IQueryAttributable
{
	
	public GenreFormPage(GenreFormViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (BindingContext is GenreFormViewModel vm)
        {
            vm.ApplyQueryAttributes(query);
        }
    }
}