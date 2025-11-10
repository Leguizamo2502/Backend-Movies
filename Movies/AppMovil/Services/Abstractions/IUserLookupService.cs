using AppMovil.Models.Implements.User;

namespace AppMovil.Services.Abstractions;

public interface IUserLookupService
{
    Task<IReadOnlyList<UserSelectDto>> GetAllAsync(CancellationToken ct = default);
}
