using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AppMovil.Models.Implements.User;
using AppMovil.Services.Abstractions;
using AppMovil.Services.Http;

namespace AppMovil.Services.Implementations;

public sealed class UserLookupService : IUserLookupService
{
    private readonly ApiClient _api;

    public UserLookupService(ApiClient api)
    {
        _api = api;
    }

    public async Task<IReadOnlyList<UserSelectDto>> GetAllAsync(CancellationToken ct = default)
    {
        var result = await _api.GetAsync<List<UserSelectDto>>("User?getAllType=0", ct);
        return result ?? [];
    }
}
