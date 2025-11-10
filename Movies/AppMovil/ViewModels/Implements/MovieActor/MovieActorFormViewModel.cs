using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppMovil.Models.Implements.Actor;
using AppMovil.Models.Implements.MovieActor;
using AppMovil.Models.Implements.Movies;
using AppMovil.Services.Abstractions;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.ViewModels.Generic;
using Microsoft.Maui.Controls;

namespace AppMovil.ViewModels.Implements.MovieActor;

public sealed class MovieActorFormViewModel
    : BaseFormViewModel<MovieActorSelectDto, MovieActorCreateDto, MovieActorUpdateDto>
{
    private readonly IMovieService _movieService;
    private readonly IActorService _actorService;
    private readonly SemaphoreSlim _optionsSemaphore = new(1, 1);

    private bool _optionsLoaded;

    public ObservableCollection<MovieSelectDto> Movies { get; } = new();
    public ObservableCollection<ActorSelectDto> Actors { get; } = new();

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

    private ActorSelectDto? _selectedActor;
    public ActorSelectDto? SelectedActor
    {
        get => _selectedActor;
        set
        {
            if (SetProperty(ref _selectedActor, value))
            {
                SaveCommand.NotifyCanExecuteChanged();
            }
        }
    }

    private string? _roleName;
    public string? RoleName
    {
        get => _roleName;
        set
        {
            if (SetProperty(ref _roleName, value))
            {
                SaveCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public MovieActorFormViewModel(
        IMovieActorService service,
        IMovieService movieService,
        IActorService actorService) : base(service)
    {
        _movieService = movieService;
        _actorService = actorService;
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

            Actors.Clear();
            var actors = await _actorService.GetAllAsync();
            foreach (var actor in actors)
            {
                Actors.Add(actor);
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
        SelectedActor = null;
        RoleName = string.Empty;
        DeleteCommand.NotifyCanExecuteChanged();
        SaveCommand.NotifyCanExecuteChanged();
    }

    protected override MovieActorCreateDto BuildCreateDto() => new()
    {
        MovieId = SelectedMovie!.Id,
        ActorId = SelectedActor!.Id,
        RoleName = string.IsNullOrWhiteSpace(RoleName) ? null : RoleName
    };

    protected override MovieActorUpdateDto BuildUpdateDto() => new()
    {
        Id = Id,
        MovieId = SelectedMovie!.Id,
        ActorId = SelectedActor!.Id,
        RoleName = string.IsNullOrWhiteSpace(RoleName) ? null : RoleName
    };

    protected override void LoadFromDto(MovieActorSelectDto dto)
    {
        Id = dto.Id;
        SelectedMovie = Movies.FirstOrDefault(m => m.Id == dto.MovieId);
        SelectedActor = Actors.FirstOrDefault(a => a.Id == dto.ActorId);
        RoleName = dto.RoleName;
        DeleteCommand.NotifyCanExecuteChanged();
        SaveCommand.NotifyCanExecuteChanged();
    }

    protected override bool CanSave()
        => !IsBusy && SelectedMovie is not null && SelectedActor is not null;
}
