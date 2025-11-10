using AppMovil.Models.Implements.Watchlist;
using AppMovil.Services.Abstractions.Generic;

namespace AppMovil.Services.Abstractions.Implements;

public interface IWatchlistService : IGenericService<WatchlistSelectDto, WatchlistCreateDto, WatchlistUpdateDto>
{
}
