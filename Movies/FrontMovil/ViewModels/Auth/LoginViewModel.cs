using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using FrontMovil.Core.Core.Abtractions;
using FrontMovil.ViewModels.Base;
using Microsoft.Extensions.Logging;

namespace FrontMovil.ViewModels.Auth;

public class LoginViewModel : ViewModelBase
{
    private readonly IApiClient _apiClient;
    private readonly ILogger<LoginViewModel> _logger;
    private string _email = string.Empty;
    private string _password = string.Empty;
    private string? _errorMessage;

    public LoginViewModel(IApiClient apiClient, ILogger<LoginViewModel> logger)
    {
        _apiClient = apiClient;
        _logger = logger;
        LoginCommand = new Command(async () => await LoginAsync(), () => !IsBusy);
    }

    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public string? ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public ICommand LoginCommand { get; }

    private async Task LoginAsync()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            (LoginCommand as Command)?.ChangeCanExecute();
            ErrorMessage = null;

            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Ingresa tu correo y contraseña.";
                return;
            }

            var result = await _apiClient.LoginAsync(Email.Trim(), Password, CancellationToken.None);
            if (result.IsSuccess)
            {
                await Shell.Current.GoToAsync("//MoviePage");
            }
            else
            {
                ErrorMessage = result.Message ?? "No se pudo iniciar sesión.";
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error inesperado durante el login");
            ErrorMessage = "Ocurrió un error inesperado. Intenta nuevamente.";
        }
        finally
        {
            IsBusy = false;
            (LoginCommand as Command)?.ChangeCanExecute();
        }
    }
}
