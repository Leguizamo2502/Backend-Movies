using AppMovil.Models.Implements.Genre;
using AppMovil.Services.Abstractions.Generic;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.ViewModels.Generic;
using CommunityToolkit.Mvvm.Input;
using System.Linq;

namespace AppMovil.ViewModels.Implements.Genre
{
    public class GenreListViewModel : BaseListViewModel<GenreSelectDto, GenreCreateDto, GenreUpdateDto>
    {

        public IRelayCommand CreateCommand { get; }
        public IAsyncRelayCommand<GenreSelectDto> EditCommand { get; }
        public IAsyncRelayCommand<GenreSelectDto> DeleteCommand { get; }

        private readonly IGenreService _genreService;

        public GenreListViewModel(IGenreService service) : base(service)
        {
            Title = "Géneros";
            _genreService = service;

            CreateCommand = new RelayCommand(async () => await Shell.Current.GoToAsync("genre/form"));
            EditCommand = new AsyncRelayCommand<GenreSelectDto>(EditAsync);
            DeleteCommand = new AsyncRelayCommand<GenreSelectDto>(DeleteAsync);

        }

        private Task EditAsync(GenreSelectDto? genre)
        {
            if (genre is null) return Task.CompletedTask;
            return Shell.Current.GoToAsync($"genre/form?id={genre.Id}");
        }

        private async Task DeleteAsync(GenreSelectDto? genre)
        {
            if (genre is null) return;

            var ok = await Shell.Current.DisplayAlert("Eliminar",
                $"¿Eliminar a \"{genre.Name}\"?", "Sí", "No");
            if (!ok) return;

            try
            {
                IsBusy = true;
                await _genreService.DeleteAsync(genre.Id);
                var idx = Items.IndexOf(genre);
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
