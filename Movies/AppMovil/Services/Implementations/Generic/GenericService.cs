using AppMovil.Services.Abstractions.Generic;
using AppMovil.Services.Http;

namespace AppMovil.Services.Implementations.Generic
{
    public class GenericService<TSelect, TCreate, TUpdate>
    : IGenericService<TSelect, TCreate, TUpdate>
    {
        private readonly ApiClient _api;
        private readonly string _endpoint;

        public GenericService(ApiClient api, string endpoint)
        {
            _api = api;
            _endpoint = endpoint;
        }

        public Task<IEnumerable<TSelect>> GetAllAsync()
            => _api.GetAsync<IEnumerable<TSelect>>($"{_endpoint}?getAllType=0");

        public Task<TSelect?> GetAsync(int id)
            => _api.GetAsync<TSelect>($"{_endpoint}/{id}");

        public async Task<int> CreateAsync(TCreate dto)
        {
            var result = await _api.PostAsync<TCreate, TSelect>(_endpoint, dto);
            return result?.GetType().GetProperty("Id")?.GetValue(result) as int? ?? 0;
        }

        public Task UpdateAsync(int id, TUpdate dto)
            => _api.PutAsync($"{_endpoint}/{id}", dto);

        public Task DeleteAsync(int id)
            => _api.DeleteAsync($"{_endpoint}/{id}");
    }
}
