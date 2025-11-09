using Entity.DTOs.Catalog.Movie.Select;
using FrontMovil.Core.Models;

namespace FrontMovil.Core.Core.Abtractions;

public interface IApiClient
{
    Task<ApiResult<bool>> LoginAsync(string email, string password, CancellationToken cancellationToken = default);
    Task<ApiResult<bool>> LogoutAsync(CancellationToken cancellationToken = default);
    Task<ApiResult<IReadOnlyList<MovieSelectDto>>> GetMoviesAsync(CancellationToken cancellationToken = default);
}
