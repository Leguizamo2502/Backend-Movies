using AppMovil.Models.Implements.Users;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.ViewModels.Generic;

namespace AppMovil.ViewModels.Implements.Users
{
    public class UserFormViewModel : BaseFormViewModel<UserSelectDto,UserCreateDto, UserUpdateDto>  
    {
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set
            {
                if (SetProperty(ref _name, value))
                    SaveCommand.NotifyCanExecuteChanged();
            }
        }

        private string _email = string.Empty;
        public string Email
        {
            get => _email;
            set
            {
                if (SetProperty(ref _email, value))
                    SaveCommand.NotifyCanExecuteChanged();
            }
        }

        private string _password = string.Empty;    
        public string Password
        {
            get => _password;
            set
            {
                if (SetProperty(ref _password, value))
                    SaveCommand.NotifyCanExecuteChanged();
            }
        }

        public UserFormViewModel(IUserService service) : base(service)
        {
        }


        // DTOs de creación y actualización
        protected override UserCreateDto BuildCreateDto() => new()
        {
            Name = Name,
            Email = Email,
            Password = Password
        };

        protected override UserUpdateDto BuildUpdateDto() => new()
        {
            Id = Id,
            Name = Name,
            Email = Email,
            Password = Password
        };

        // Carga los datos del DTO de selección
        protected override void LoadFromDto(UserSelectDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Email = dto.Email;
            //Password = dto.Password
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("id", out var raw) && raw is string s && int.TryParse(s, out var id) && id > 0)
            {
                Id = id;
                DeleteCommand.NotifyCanExecuteChanged();

                _ = LoadAsync(id);
                return;
            }

            Id = 0;
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            DeleteCommand.NotifyCanExecuteChanged();
        }


    }
}
