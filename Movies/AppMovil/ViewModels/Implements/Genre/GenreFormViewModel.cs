using AppMovil.Models.Implements.Genre;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.ViewModels.Generic;

namespace AppMovil.ViewModels.Implements.Genre
{
    public class GenreFormViewModel : BaseFormViewModel<GenreSelectDto,GenreCreateDto,GenreUpdateDto>
    {
        //Form
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

        public GenreFormViewModel(IGenreService service) : base(service)
        {
        }

        protected override GenreCreateDto BuildCreateDto() => new()
        {
            Name = Name
        };

        protected override GenreUpdateDto BuildUpdateDto() => new()
        {
            Id = Id,
            Name = Name
        };
        
        //cargar

        protected override void LoadFromDto(GenreSelectDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
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
            DeleteCommand.NotifyCanExecuteChanged();
        }

    }
}
