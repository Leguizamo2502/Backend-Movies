using AppMovil.Models.Implements.Watchlist;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.Services.Http;
using AppMovil.Services.Implementations.Generic;

namespace AppMovil.Services.Implementations.Implements;

public sealed class WatchlistService : GenericService<WatchlistSelectDto, WatchlistCreateDto, WatchlistUpdateDto>, IWatchlistService
{
    public WatchlistService(ApiClient api) : base(api, "Watchlist")
    {
    }
}
