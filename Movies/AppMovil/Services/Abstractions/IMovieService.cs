using AppMovil.Models.Implements.Movies;

namespace AppMovil.Services.Abstractions
{
    public interface IMovieService
    {
        Task<IReadOnlyList<MovieSelectDto>> GetAllAsync(CancellationToken ct = default);
    }
}
