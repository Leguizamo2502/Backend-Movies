using AppMovil.Models.Implements.Actor;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.ViewModels.Generic;
using CommunityToolkit.Mvvm.Input;

namespace AppMovil.ViewModels.Implements.Actor
{
    public sealed class ActorListViewModel
        : BaseListViewModel<ActorSelectDto, ActorCreateDto, ActorUpdateDto>
    {
        public IRelayCommand CreateCommand { get; }
        public IAsyncRelayCommand<ActorSelectDto> EditCommand { get; }
        public IAsyncRelayCommand<ActorSelectDto> DeleteCommand { get; }

        private readonly IActorService _actorService;

        public ActorListViewModel(IActorService service) : base(service)
        {
            Title = "Actores";
            _actorService = service;

            CreateCommand = new RelayCommand(async () => await Shell.Current.GoToAsync("actor/form"));
            EditCommand = new AsyncRelayCommand<ActorSelectDto>(EditAsync);
            DeleteCommand = new AsyncRelayCommand<ActorSelectDto>(DeleteAsync);
        }

        private Task EditAsync(ActorSelectDto? actor)
        {
            if (actor is null) return Task.CompletedTask;
            return Shell.Current.GoToAsync($"actor/form?id={actor.Id}");
        }

        private async Task DeleteAsync(ActorSelectDto? actor)
        {
            if (actor is null) return;

            var ok = await Shell.Current.DisplayAlert("Eliminar",
                $"¿Eliminar a \"{actor.Name}\"?", "Sí", "No");
            if (!ok) return;

            try
            {
                IsBusy = true;
                await _actorService.DeleteAsync(actor.Id);
                // Quita de la lista sin recargar todo
                var idx = Items.IndexOf(actor);
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
