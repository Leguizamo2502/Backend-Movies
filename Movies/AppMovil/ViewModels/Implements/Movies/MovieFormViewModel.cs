using AppMovil.Models.Implements.Movies;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.ViewModels.Generic;

namespace AppMovil.ViewModels.Implements.Movies
{
    public class MovieFormViewModel : BaseFormViewModel<MovieSelectDto,MovieCreateDto,MovieUpdateDto>
    {

        //Form
        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set
            {
                if (SetProperty(ref _title, value))
                    SaveCommand.NotifyCanExecuteChanged();
            }
        }

        private int? _releaseYear;
        public int? ReleaseYear
        {
            get => _releaseYear;
            set
            {
                if (SetProperty(ref _releaseYear, value))
                    SaveCommand.NotifyCanExecuteChanged();
            }
        }

        private int? _durationMinutes;
        public int? DurationMinutes
        {
            get => _durationMinutes;
            set
            {
                if (SetProperty(ref _durationMinutes, value))
                    SaveCommand.NotifyCanExecuteChanged();
            }
        }

        private string _description = string.Empty;
        public string Description
        {
            get => _description;
            set
            {
                if (SetProperty(ref _description, value))
                    SaveCommand.NotifyCanExecuteChanged();
            }
        }

        public MovieFormViewModel(IMovieService service) : base(service)
        {
        }

        // DTOs de creación y actualización
        protected override MovieCreateDto BuildCreateDto() => new()
        {
            Title = Title,
            ReleaseYear = ReleaseYear,
            DurationMinutes = DurationMinutes,
            Description = Description
        };

        protected override MovieUpdateDto BuildUpdateDto() => new()
        {
            Id = Id,
            Title = Title,
            ReleaseYear = ReleaseYear,
            DurationMinutes = DurationMinutes,
            Description = Description
        };

        // Carga los datos del DTO de selección
        protected override void LoadFromDto(MovieSelectDto dto)
        {
            Id = dto.Id;
            Title = dto.Title;
            ReleaseYear = dto.ReleaseYear;
            DurationMinutes = dto.DurationMinutes;
            Description = dto.Description;
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
            Title = string.Empty;
            ReleaseYear = null;
            DurationMinutes = null;
            Description = string.Empty;
            DeleteCommand.NotifyCanExecuteChanged();
        }


    }
}
