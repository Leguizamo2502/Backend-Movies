using AppMovil.Services.Abstractions;
using AppMovil.Models.Implements.Movies;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AppMovil.ViewModels.Movies
{
    public sealed class MovieListViewModel : ObservableObject
    {
        private readonly IMovieService _service;

        // Spinner general (ActivityIndicator de la página)
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        // Spinner del RefreshView (pull-to-refresh)
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        private string? _title = "Películas";
        public string? Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ObservableCollection<MovieSelectDto> Items { get; } = new();

        public IAsyncRelayCommand LoadAsyncCommand { get; }

        public MovieListViewModel(IMovieService service)
        {
            _service = service;
            LoadAsyncCommand = new AsyncRelayCommand(LoadAsync);
        }

        private async Task LoadAsync()
        {
            // evita cargas concurrentes
            if (IsBusy) return;

            try
            {
                IsBusy = true;       // ActivityIndicator
                Items.Clear();

                var movies = await _service.GetAllAsync();
                foreach (var movie in movies)
                    Items.Add(movie);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error",
                    $"No se pudo cargar la lista: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;       // fin del indicador general
                IsRefreshing = false; // apaga el spinner del RefreshView
            }
        }
    }
}
