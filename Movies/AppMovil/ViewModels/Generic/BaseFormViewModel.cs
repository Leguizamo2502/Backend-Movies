using AppMovil.Services.Abstractions.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMovil.ViewModels.Generic
{
    public abstract class BaseFormViewModel<TSelect, TCreate, TUpdate> : ObservableObject
    {
        protected readonly IGenericService<TSelect, TCreate, TUpdate> _service;

        // --------- Propiedades manuales (sin source generators) ---------
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
        // ----------------------------------------------------------------

        // Comandos públicos del formulario
        public IAsyncRelayCommand SaveCommand { get; }
        public IAsyncRelayCommand DeleteCommand { get; }

        protected BaseFormViewModel(IGenericService<TSelect, TCreate, TUpdate> service)
        {
            _service = service;

            SaveCommand = new AsyncRelayCommand(SaveAsync, CanSave);
            DeleteCommand = new AsyncRelayCommand(DeleteAsync, () => Id > 0);
        }

        // ---- Para que cada VM concreto construya/sincronice sus DTOs ----
        protected abstract TCreate BuildCreateDto();
        protected abstract TUpdate BuildUpdateDto();
        protected abstract void LoadFromDto(TSelect dto);
        // -----------------------------------------------------------------

        // Hook opcional para validación extra en Guardar
        protected virtual bool CanSave() => !IsBusy;

        // Hooks opcionales después de operaciones (para notificaciones, refresh, etc.)
        protected virtual Task AfterSaveAsync() => Task.CompletedTask;
        protected virtual Task AfterDeleteAsync() => Task.CompletedTask;

        public async Task LoadAsync(int id)
        {
            if (id <= 0) return;

            try
            {
                IsBusy = true;
                var dto = await _service.GetAsync(id);
                if (dto is not null)
                {
                    LoadFromDto(dto);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"No se pudo cargar: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task SaveAsync()
        {
            if (!CanSave()) return;

            try
            {
                IsBusy = true;

                if (Id == 0)
                {
                    Id = await _service.CreateAsync(BuildCreateDto());
                }
                else
                {
                    await _service.UpdateAsync(Id, BuildUpdateDto());
                }

                await AfterSaveAsync();
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"No se pudo guardar: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
                SaveCommand.NotifyCanExecuteChanged();
            }
        }

        public async Task DeleteAsync()
        {
            if (Id <= 0) return;

            var confirm = await Shell.Current.DisplayAlert("Confirmar", "¿Eliminar este registro?", "Sí", "No");
            if (!confirm) return;

            try
            {
                IsBusy = true;
                await _service.DeleteAsync(Id);
                await AfterDeleteAsync();
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"No se pudo eliminar: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
