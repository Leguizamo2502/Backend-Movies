using AppMovil.Models.Implements.Movies;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.ViewModels.Generic;
using CommunityToolkit.Mvvm.Input;

namespace AppMovil.ViewModels.Implements.Movies
{
    public class MovieListViewModel : BaseListViewModel<MovieSelectDto,MovieCreateDto,MovieUpdateDto>
    {
        public IRelayCommand CreateCommand { get; }
        public IAsyncRelayCommand<MovieSelectDto> EditCommand { get; }
        public IAsyncRelayCommand<MovieSelectDto> DeleteCommand { get; }

        private readonly IMovieService _movieService;

        public MovieListViewModel(IMovieService service) : base(service)
        {
            Title = "Películas";
            _movieService = service;
            CreateCommand = new RelayCommand(async () => await Shell.Current.GoToAsync("movie/form"));
            EditCommand = new AsyncRelayCommand<MovieSelectDto>(EditAsync);
            DeleteCommand = new AsyncRelayCommand<MovieSelectDto>(DeleteAsync);

        }

        private Task EditAsync(MovieSelectDto? movie)
        {
            if (movie is null) return Task.CompletedTask;
            return Shell.Current.GoToAsync($"movie/form?id={movie.Id}");
        }

        private async Task DeleteAsync(MovieSelectDto? movie)
        {
            if (movie is null) return;

            var ok = await Shell.Current.DisplayAlert("Eliminar",
                $"¿Eliminar a \"{movie.Title}\"?", "Sí", "No");
            if (!ok) return;

            try
            {
                IsBusy = true;
                await _movieService.DeleteAsync(movie.Id);
                // Quita de la lista sin recargar todo
                var idx = Items.IndexOf(movie);
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
