using AppMovil.Models.Implements.Actor;
using AppMovil.Services.Abstractions.Generic;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.ViewModels.Generic;

namespace AppMovil.ViewModels.Implements.Actor
{
    public sealed class ActorFormViewModel
        : BaseFormViewModel<ActorSelectDto, ActorCreateDto, ActorUpdateDto>
    {
        // Propiedades del formulario
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

        private int? _birthYear;
        public int? BirthYear
        {
            get => _birthYear;
            set
            {
                if (SetProperty(ref _birthYear, value))
                    SaveCommand.NotifyCanExecuteChanged();
            }
        }

        // Constructor: recibe el servicio genérico ya inyectado
        public ActorFormViewModel(IActorService service)
            : base(service)
        {
        }

        // DTOs de creación y actualización
        protected override ActorCreateDto BuildCreateDto() => new()
        {
            Name = Name,
            BirthYear = BirthYear
        };

        protected override ActorUpdateDto BuildUpdateDto() => new()
        {
            Id = Id,
            Name = Name,
            BirthYear = BirthYear
        };

        // Carga los datos del DTO de selección
        protected override void LoadFromDto(ActorSelectDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            BirthYear = dto.BirthYear;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            // Clave: "id" (minúsculas) porque navegas con ?id=...
            if (query.TryGetValue("id", out var raw) && raw is string s && int.TryParse(s, out var id) && id > 0)
            {
                Id = id;                  // <- propiedad de BaseFormViewModel
                _ = LoadAsync(id);        // <- método de BaseFormViewModel (ya lo tienes)
            }
        }

        // Validación antes de guardar
        protected override bool CanSave()
            => !IsBusy && !string.IsNullOrWhiteSpace(Name) && BirthYear is >= 1900 and <= 2100;
    }
}
