using System;
using System.Threading.Tasks;
using AppMovil.Models.Implements.MovieGenre;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.ViewModels.Generic;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace AppMovil.ViewModels.Implements.MovieGenre;

public sealed class MovieGenreListViewModel
    : BaseListViewModel<MovieGenreSelectDto, MovieGenreCreateDto, MovieGenreUpdateDto>
{
    public IRelayCommand CreateCommand { get; }
    public IAsyncRelayCommand<MovieGenreSelectDto> EditCommand { get; }
    public IAsyncRelayCommand<MovieGenreSelectDto> DeleteCommand { get; }

    private readonly IMovieGenreService _movieGenreService;

    public MovieGenreListViewModel(IMovieGenreService service) : base(service)
    {
        Title = "Películas por género";
        _movieGenreService = service;

        CreateCommand = new RelayCommand(async () => await Shell.Current.GoToAsync("moviegenre/form"));
        EditCommand = new AsyncRelayCommand<MovieGenreSelectDto>(EditAsync);
        DeleteCommand = new AsyncRelayCommand<MovieGenreSelectDto>(DeleteAsync);
    }

    private Task EditAsync(MovieGenreSelectDto? item)
    {
        if (item is null) return Task.CompletedTask;
        return Shell.Current.GoToAsync($"moviegenre/form?id={item.Id}");
    }

    private async Task DeleteAsync(MovieGenreSelectDto? item)
    {
        if (item is null) return;

        var ok = await Shell.Current.DisplayAlert("Eliminar", $"¿Quitar el género '{item.GenreName}' de '{item.Title}'?", "Sí", "No");
        if (!ok) return;

        try
        {
            IsBusy = true;
            await _movieGenreService.DeleteAsync(item.Id);

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
