using System;
using System.Threading.Tasks;
using AppMovil.Models.Implements.Watchlist;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.ViewModels.Generic;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace AppMovil.ViewModels.Implements.Watchlist;

public sealed class WatchlistListViewModel
    : BaseListViewModel<WatchlistSelectDto, WatchlistCreateDto, WatchlistUpdateDto>
{
    public IRelayCommand CreateCommand { get; }
    public IAsyncRelayCommand<WatchlistSelectDto> EditCommand { get; }
    public IAsyncRelayCommand<WatchlistSelectDto> DeleteCommand { get; }

    private readonly IWatchlistService _watchlistService;

    public WatchlistListViewModel(IWatchlistService service) : base(service)
    {
        Title = "Watchlists";
        _watchlistService = service;

        CreateCommand = new RelayCommand(async () => await Shell.Current.GoToAsync("watchlist/form"));
        EditCommand = new AsyncRelayCommand<WatchlistSelectDto>(EditAsync);
        DeleteCommand = new AsyncRelayCommand<WatchlistSelectDto>(DeleteAsync);
    }

    private Task EditAsync(WatchlistSelectDto? item)
    {
        if (item is null) return Task.CompletedTask;
        return Shell.Current.GoToAsync($"watchlist/form?id={item.Id}");
    }

    private async Task DeleteAsync(WatchlistSelectDto? item)
    {
        if (item is null) return;

        var ok = await Shell.Current.DisplayAlert("Eliminar",
            $"¿Eliminar '{item.Title}' de la lista de {item.UserName}?", "Sí", "No");
        if (!ok) return;

        try
        {
            IsBusy = true;
            await _watchlistService.DeleteAsync(item.Id);

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
