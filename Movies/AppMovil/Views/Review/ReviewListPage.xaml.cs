using AppMovil.ViewModels.Implements.Review;
using Microsoft.Maui.Controls;

namespace AppMovil.Views.Review;

public partial class ReviewListPage : ContentPage
{
    private readonly ReviewListViewModel _vm;

    public ReviewListPage(ReviewListViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_vm.Items.Count == 0)
        {
            await _vm.LoadCommand.ExecuteAsync(null);
        }
    }
}
