using System.Collections.Generic;
using AppMovil.ViewModels.Implements.Review;
using Microsoft.Maui.Controls;

namespace AppMovil.Views.Review;

public partial class ReviewFormPage : ContentPage, IQueryAttributable
{
    public ReviewFormPage(ReviewFormViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (BindingContext is ReviewFormViewModel vm)
        {
            vm.ApplyQueryAttributes(query);
        }
    }
}
