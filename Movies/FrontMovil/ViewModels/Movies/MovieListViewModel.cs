using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Entity.DTOs.Catalog.Movie.Select;
using FrontMovil.Core.Core.Abtractions;
using FrontMovil.ViewModels.Base;
using Microsoft.Extensions.Logging;

namespace FrontMovil.ViewModels.Movies;

public class MovieListViewModel : ViewModelBase
{
    private readonly IApiClient _apiClient;
    private readonly ILogger<MovieListViewModel> _logger;
    private bool _isInitialized;
    private string? _statusMessage;

    public MovieListViewModel(IApiClient apiClient, ILogger<MovieListViewModel> logger)
    {
        _apiClient = apiClient;
        _logger = logger;
        Movies = new ObservableCollection<MovieSelectDto>();
        RefreshCommand = new Command(async () => await LoadMoviesAsync(true));
        LogoutCommand = new Command(async () => await LogoutAsync(), () => !IsBusy);
    }

    public ObservableCollection<MovieSelectDto> Movies { get; }

    public string? StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public ICommand RefreshCommand { get; }
    public ICommand LogoutCommand { get; }

    public async Task InitializeAsync()
    {
        if (_isInitialized)
        {
            return;
        }

        await LoadMoviesAsync(false);
        _isInitialized = true;
    }

    private async Task LoadMoviesAsync(bool forceRefresh)
    {
        if (IsBusy && !forceRefresh)
        {
            return;
        }

        try
        {
            IsBusy = true;
            StatusMessage = null;
            UpdateLogoutAvailability();

            var result = await _apiClient.GetMoviesAsync(CancellationToken.None);
            if (result.IsSuccess && result.Data is not null)
            {
                Movies.Clear();
                foreach (var movie in result.Data)
                {
                    Movies.Add(movie);
                }

                StatusMessage = result.Message;
            }
            else
            {
                StatusMessage = result.Message ?? "No se pudieron cargar las películas.";
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error cargando la lista de películas");
            StatusMessage = "Ocurrió un error al obtener las películas.";
        }
        finally
        {
            IsBusy = false;
            UpdateLogoutAvailability();
        }
    }

    private async Task LogoutAsync()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            UpdateLogoutAvailability();

            var result = await _apiClient.LogoutAsync(CancellationToken.None);
            StatusMessage = result.Message;
            await Shell.Current.GoToAsync("//LoginPage");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error durante el cierre de sesión");
            StatusMessage = "Ocurrió un error al cerrar sesión.";
        }
        finally
        {
            IsBusy = false;
            UpdateLogoutAvailability();
        }
    }

    private void UpdateLogoutAvailability() => (LogoutCommand as Command)?.ChangeCanExecute();
}
