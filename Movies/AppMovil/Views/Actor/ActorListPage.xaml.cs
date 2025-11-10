using AppMovil.ViewModels.Implements.Actor;

namespace AppMovil.Views.Actor;

public partial class ActorListPage : ContentPage
{
    private readonly ActorListViewModel _vm;

    public ActorListPage(ActorListViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Solo carga si la lista está vacía (evita doble carga)
        if (_vm.Items.Count == 0)
            await _vm.LoadCommand.ExecuteAsync(null);
    }
}