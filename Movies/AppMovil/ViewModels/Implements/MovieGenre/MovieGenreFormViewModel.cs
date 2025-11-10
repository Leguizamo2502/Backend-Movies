using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppMovil.Models.Implements.Genre;
using AppMovil.Models.Implements.MovieGenre;
using AppMovil.Models.Implements.Movies;
using AppMovil.Services.Abstractions;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.ViewModels.Generic;
using Microsoft.Maui.Controls;

namespace AppMovil.ViewModels.Implements.MovieGenre;

public sealed class MovieGenreFormViewModel
    : BaseFormViewModel<MovieGenreSelectDto, MovieGenreCreateDto, MovieGenreUpdateDto>
{
    private readonly IMovieService _movieService;
    private readonly IGenreService _genreService;
    private readonly SemaphoreSlim _optionsSemaphore = new(1, 1);

    private bool _optionsLoaded;

    public ObservableCollection<MovieSelectDto> Movies { get; } = new();
    public ObservableCollection<GenreSelectDto> Genres { get; } = new();

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

    private GenreSelectDto? _selectedGenre;
    public GenreSelectDto? SelectedGenre
    {
        get => _selectedGenre;
        set
        {
            if (SetProperty(ref _selectedGenre, value))
            {
                SaveCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public MovieGenreFormViewModel(
        IMovieGenreService service,
        IMovieService movieService,
        IGenreService genreService) : base(service)
    {
        _movieService = movieService;
        _genreService = genreService;
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

            Genres.Clear();
            var genres = await _genreService.GetAllAsync();
            foreach (var genre in genres)
            {
                Genres.Add(genre);
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
        SelectedGenre = null;
        DeleteCommand.NotifyCanExecuteChanged();
        SaveCommand.NotifyCanExecuteChanged();
    }

    protected override MovieGenreCreateDto BuildCreateDto() => new()
    {
        MovieId = SelectedMovie!.Id,
        GenreId = SelectedGenre!.Id
    };

    protected override MovieGenreUpdateDto BuildUpdateDto() => new()
    {
        Id = Id,
        MovieId = SelectedMovie!.Id,
        GenreId = SelectedGenre!.Id
    };

    protected override void LoadFromDto(MovieGenreSelectDto dto)
    {
        Id = dto.Id;
        SelectedMovie = Movies.FirstOrDefault(m => m.Id == dto.MovieId);
        SelectedGenre = Genres.FirstOrDefault(g => g.Id == dto.GenreId);
        DeleteCommand.NotifyCanExecuteChanged();
        SaveCommand.NotifyCanExecuteChanged();
    }

    protected override bool CanSave()
        => !IsBusy && SelectedMovie is not null && SelectedGenre is not null;
}
