using System;
using System.Threading.Tasks;
using AppMovil.Models.Implements.Review;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.ViewModels.Generic;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace AppMovil.ViewModels.Implements.Review;

public sealed class ReviewListViewModel
    : BaseListViewModel<ReviewSelectDto, ReviewCreateDto, ReviewUpdateDto>
{
    public IRelayCommand CreateCommand { get; }
    public IAsyncRelayCommand<ReviewSelectDto> EditCommand { get; }
    public IAsyncRelayCommand<ReviewSelectDto> DeleteCommand { get; }

    private readonly IReviewService _reviewService;

    public ReviewListViewModel(IReviewService service) : base(service)
    {
        Title = "Reseñas";
        _reviewService = service;

        CreateCommand = new RelayCommand(async () => await Shell.Current.GoToAsync("review/form"));
        EditCommand = new AsyncRelayCommand<ReviewSelectDto>(EditAsync);
        DeleteCommand = new AsyncRelayCommand<ReviewSelectDto>(DeleteAsync);
    }

    private Task EditAsync(ReviewSelectDto? item)
    {
        if (item is null) return Task.CompletedTask;
        return Shell.Current.GoToAsync($"review/form?id={item.Id}");
    }

    private async Task DeleteAsync(ReviewSelectDto? item)
    {
        if (item is null) return;

        var ok = await Shell.Current.DisplayAlert("Eliminar",
            $"¿Eliminar la reseña de {item.UserName} para '{item.Title}'?", "Sí", "No");
        if (!ok) return;

        try
        {
            IsBusy = true;
            await _reviewService.DeleteAsync(item.Id);

            var index = Items.IndexOf(item);
            if (index >= 0)
            {
                Items.RemoveAt(index);
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
