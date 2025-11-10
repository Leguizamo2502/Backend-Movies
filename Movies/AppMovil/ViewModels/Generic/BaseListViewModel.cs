using AppMovil.Services.Abstractions.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AppMovil.ViewModels.Generic
{
    public abstract class BaseListViewModel<TSelect,TCreate,TUpdate> : ObservableObject
    {
        protected readonly IGenericService<TSelect, TCreate, TUpdate> _service;

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        private string? _title;
        public string? Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ObservableCollection<TSelect> Items { get; } = new();

        public IAsyncRelayCommand LoadCommand { get; }

        protected BaseListViewModel(IGenericService<TSelect, TCreate, TUpdate> service)
        {
            _service = service;
            LoadCommand = new AsyncRelayCommand(LoadAsync);
        }

        protected virtual async Task LoadAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                Items.Clear();

                var data = await _service.GetAllAsync();
                foreach (var item in data)
                    Items.Add(item);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}
