using AppMovil.Models.Implements.Auth;
using AppMovil.Services.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace AppMovil.ViewModels.Implements.Auth;

public sealed class LoginViewModel : ObservableObject
{
    private readonly IAuthService _authService;

    private string _email = string.Empty;
    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    private string _password = string.Empty;
    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (SetProperty(ref _isBusy, value))
            {
                OnPropertyChanged(nameof(IsNotBusy));
                LoginCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public bool IsNotBusy => !IsBusy;

    private string? _errorMessage;
    public string? ErrorMessage
    {
        get => _errorMessage;
        set
        {
            if (SetProperty(ref _errorMessage, value))
            {
                OnPropertyChanged(nameof(HasError));
            }
        }
    }

    public bool HasError => !string.IsNullOrWhiteSpace(ErrorMessage);

    public IAsyncRelayCommand LoginCommand { get; }

    public LoginViewModel(IAuthService authService)
    {
        _authService = authService;
        LoginCommand = new AsyncRelayCommand(LoginAsync, () => IsNotBusy);
    }

    private async Task LoginAsync()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            await DisplayAlertAsync("Datos faltantes", "Ingresa tu correo y contraseña.");
            return;
        }

        try
        {
            ErrorMessage = null;
            IsBusy = true;

            var result = await _authService.LoginAsync(new LoginRequestDto
            {
                Email = Email.Trim(),
                Password = Password
            });

            if (!result.IsSuccess)
            {
                ErrorMessage = result.Message ?? "No se pudo iniciar sesión.";
                return;
            }

            await DisplayAlertAsync("Bienvenido", result.Message ?? "Inicio de sesión exitoso.");

            var app = Application.Current;
            if (app is not null)
            {
                if (app.Dispatcher.IsDispatchRequired)
                {
                    app.Dispatcher.Dispatch(() => app.MainPage = new AppShell());
                }
                else
                {
                    app.MainPage = new AppShell();
                }
            }
        }
        catch (InvalidOperationException ex)
        {
            ErrorMessage = ex.Message;
        }
        catch (Exception ex)
        {
            ErrorMessage = "Ocurrió un error inesperado. Inténtalo nuevamente.";
#if DEBUG
            System.Diagnostics.Debug.WriteLine(ex);
#endif
        }
        finally
        {
            IsBusy = false;
        }
    }

    private static Task DisplayAlertAsync(string title, string message)
    {
        var page = Application.Current?.MainPage;
        return page is not null
            ? page.DisplayAlert(title, message, "OK")
            : Task.CompletedTask;
    }
}
