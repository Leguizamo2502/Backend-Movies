using AppMovil.Config;
using System.Net.Http.Json;

namespace AppMovil.Services.Http
{
    public sealed class ApiClient
    {
        private readonly HttpClient _http;

        public ApiClient(HttpClient http, ApiOptions options)
        {
            http.BaseAddress = new Uri(options.BaseUrl);
            _http = http;
        }

        // =======================================================
        // MÉTODOS CRUD GENÉRICOS
        // =======================================================

        // GET
        public Task<T?> GetAsync<T>(string uri, CancellationToken ct = default)
            => _http.GetFromJsonAsync<T>(uri, ct);

        // POST
        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string uri, TRequest data, CancellationToken ct = default)
        {
            var response = await _http.PostAsJsonAsync(uri, data, ct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: ct);
        }

        // PUT
        public async Task PutAsync<TRequest>(string uri, TRequest data, CancellationToken ct = default)
        {
            var response = await _http.PutAsJsonAsync(uri, data, ct);
            response.EnsureSuccessStatusCode();
        }

        // DELETE
        public async Task DeleteAsync(string uri, CancellationToken ct = default)
        {
            var response = await _http.DeleteAsync(uri, ct);
            response.EnsureSuccessStatusCode();
        }
    }
}
