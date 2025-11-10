using AppMovil.ViewModels.Implements.Actor;

namespace AppMovil.Views.Actor;

public partial class ActorFormPage : ContentPage
{
    public ActorFormPage(ActorFormViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Si el ViewModel tiene un ID (navegación con parámetros), carga los datos
        if (BindingContext is ActorFormViewModel vm && vm.Id > 0)
            await vm.LoadAsync(vm.Id);
    }
}