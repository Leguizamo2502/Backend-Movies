using AppMovil.ViewModels.Implements.Movies;

namespace AppMovil.Views.Movies;

public partial class MovieFormPage : ContentPage,IQueryAttributable
{
	public MovieFormPage(MovieFormViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (BindingContext is MovieFormViewModel vm)
        {
            vm.ApplyQueryAttributes(query);
        }
    }
}