using AppMovil.Config;
using AppMovil.Services.Abstractions;
using AppMovil.Services.Http;
using AppMovil.Models.Implements.Movies;

namespace AppMovil.Services.Implementations
{
    public sealed class MovieService : IMovieService
    {
        private readonly ApiClient _api;

        public MovieService(ApiClient api)
        {
            _api = api;
        }

        public async Task<IReadOnlyList<MovieSelectDto>> GetAllAsync(CancellationToken ct = default)
        {
            var result = await _api.GetAsync<List<MovieSelectDto>>(ApiRoutes.Movies, ct);
            return result ?? [];
        }
    }
}
