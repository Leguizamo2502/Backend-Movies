using AppMovil.ViewModels.Implements.Actor;

namespace AppMovil.Views.Actor;

public partial class ActorFormPage : ContentPage, IQueryAttributable
{
    public ActorFormPage(ActorFormViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (BindingContext is ActorFormViewModel vm)
        {
            vm.ApplyQueryAttributes(query);
        }
    }
}
