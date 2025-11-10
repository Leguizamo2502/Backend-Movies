using AppMovil.Models.Implements.Users;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.ViewModels.Generic;
using CommunityToolkit.Mvvm.Input;
using System.Linq;

namespace AppMovil.ViewModels.Implements.Users
{
    public class UserListViewModel : BaseListViewModel<UserSelectDto, UserCreateDto, UserUpdateDto>
    {
        public IRelayCommand CreateCommand { get; }
        public IAsyncRelayCommand<UserSelectDto> EditCommand { get; }
        public IAsyncRelayCommand<UserSelectDto> DeleteCommand { get; }

        private readonly IUserService _userService;

        public UserListViewModel(IUserService service) : base(service)
        {
            Title = "Usuarios";
            _userService = service;
            CreateCommand = new RelayCommand(async () => await Shell.Current.GoToAsync("user/form"));
            EditCommand = new AsyncRelayCommand<UserSelectDto>(EditAsync);
            DeleteCommand = new AsyncRelayCommand<UserSelectDto>(DeleteAsync);
        }


        private Task EditAsync(UserSelectDto? user)
        {
            if (user is null) return Task.CompletedTask;
            return Shell.Current.GoToAsync($"user/form?id={user.Id}");
        }

        private async Task DeleteAsync(UserSelectDto? user)
        {
            if (user is null) return;

            var ok = await Shell.Current.DisplayAlert("Eliminar",
                $"¿Eliminar a \"{user.Name}\"?", "Sí", "No");
            if (!ok) return;

            try
            {
                IsBusy = true;
                await _userService.DeleteAsync(user.Id);
                var idx = Items.IndexOf(user);
                if (idx >= 0) Items.RemoveAt(idx);
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
}
