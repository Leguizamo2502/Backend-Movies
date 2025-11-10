using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppMovil.Models.Implements.Movies;
using AppMovil.Models.Implements.User;
using AppMovil.Models.Implements.Watchlist;
using AppMovil.Services.Abstractions;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.ViewModels.Generic;
using Microsoft.Maui.Controls;

namespace AppMovil.ViewModels.Implements.Watchlist;

public sealed class WatchlistFormViewModel
    : BaseFormViewModel<WatchlistSelectDto, WatchlistCreateDto, WatchlistUpdateDto>
{
    private readonly IMovieService _movieService;
    private readonly IUserLookupService _userLookupService;
    private readonly SemaphoreSlim _optionsSemaphore = new(1, 1);

    private bool _optionsLoaded;

    public ObservableCollection<MovieSelectDto> Movies { get; } = new();
    public ObservableCollection<UserSelectDto> Users { get; } = new();

    private MovieSelectDto? _selectedMovie;
    public MovieSelectDto? SelectedMovie
    {
        get => _selectedMovie;
        set
        {
            if (SetProperty(ref _selectedMovie, value))
            {
                SaveCommand.NotifyCanExecuteChanged();
            }
        }
    }

    private UserSelectDto? _selectedUser;
    public UserSelectDto? SelectedUser
    {
        get => _selectedUser;
        set
        {
            if (SetProperty(ref _selectedUser, value))
            {
                SaveCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public WatchlistFormViewModel(
        IWatchlistService service,
        IMovieService movieService,
        IUserLookupService userLookupService) : base(service)
    {
        _movieService = movieService;
        _userLookupService = userLookupService;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        _ = InitializeAsync(query);
    }

    private async Task InitializeAsync(IDictionary<string, object> query)
    {
        await EnsureOptionsAsync();

        if (query.TryGetValue("id", out var raw) && raw is string s && int.TryParse(s, out var id) && id > 0)
        {
            Id = id;
            DeleteCommand.NotifyCanExecuteChanged();
            await LoadAsync(id);
            return;
        }

        ResetForm();
    }

    private async Task EnsureOptionsAsync()
    {
        if (_optionsLoaded) return;

        await _optionsSemaphore.WaitAsync();
        try
        {
            if (_optionsLoaded) return;

            IsBusy = true;

            Movies.Clear();
            var movies = await _movieService.GetAllAsync();
            foreach (var movie in movies)
            {
                Movies.Add(movie);
            }

            Users.Clear();
            var users = await _userLookupService.GetAllAsync();
            foreach (var user in users)
            {
                Users.Add(user);
            }

            _optionsLoaded = true;
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", $"No se pudieron cargar las opciones: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
            _optionsSemaphore.Release();
            SaveCommand.NotifyCanExecuteChanged();
        }
    }

    private void ResetForm()
    {
        Id = 0;
        SelectedMovie = null;
        SelectedUser = null;
        DeleteCommand.NotifyCanExecuteChanged();
        SaveCommand.NotifyCanExecuteChanged();
    }

    protected override WatchlistCreateDto BuildCreateDto() => new()
    {
        MovieId = SelectedMovie!.Id,
        UserId = SelectedUser!.Id
    };

    protected override WatchlistUpdateDto BuildUpdateDto() => new()
    {
        Id = Id,
        MovieId = SelectedMovie!.Id,
        UserId = SelectedUser!.Id
    };

    protected override void LoadFromDto(WatchlistSelectDto dto)
    {
        Id = dto.Id;
        SelectedMovie = Movies.FirstOrDefault(m => m.Id == dto.MovieId);
        SelectedUser = Users.FirstOrDefault(u => u.Id == dto.UserId);
        DeleteCommand.NotifyCanExecuteChanged();
        SaveCommand.NotifyCanExecuteChanged();
    }

    protected override bool CanSave()
        => !IsBusy && SelectedMovie is not null && SelectedUser is not null;
}
