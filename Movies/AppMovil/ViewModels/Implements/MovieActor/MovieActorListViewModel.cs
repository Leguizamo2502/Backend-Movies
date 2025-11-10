using System;
using System.Threading.Tasks;
using AppMovil.Models.Implements.MovieActor;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.ViewModels.Generic;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace AppMovil.ViewModels.Implements.MovieActor;

public sealed class MovieActorListViewModel
    : BaseListViewModel<MovieActorSelectDto, MovieActorCreateDto, MovieActorUpdateDto>
{
    public IRelayCommand CreateCommand { get; }
    public IAsyncRelayCommand<MovieActorSelectDto> EditCommand { get; }
    public IAsyncRelayCommand<MovieActorSelectDto> DeleteCommand { get; }

    private readonly IMovieActorService _movieActorService;

    public MovieActorListViewModel(IMovieActorService service) : base(service)
    {
        Title = "Reparto";
        _movieActorService = service;

        CreateCommand = new RelayCommand(async () => await Shell.Current.GoToAsync("movieactor/form"));
        EditCommand = new AsyncRelayCommand<MovieActorSelectDto>(EditAsync);
        DeleteCommand = new AsyncRelayCommand<MovieActorSelectDto>(DeleteAsync);
    }

    private Task EditAsync(MovieActorSelectDto? item)
    {
        if (item is null) return Task.CompletedTask;
        return Shell.Current.GoToAsync($"movieactor/form?id={item.Id}");
    }

    private async Task DeleteAsync(MovieActorSelectDto? item)
    {
        if (item is null) return;

        var ok = await Shell.Current.DisplayAlert("Eliminar",
            $"¿Quitar a '{item.ActorName}' de '{item.Title}'?", "Sí", "No");
        if (!ok) return;

        try
        {
            IsBusy = true;
            await _movieActorService.DeleteAsync(item.Id);

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
