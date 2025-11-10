using AppMovil.Models.Base;

namespace AppMovil.Models.Implements.Watchlist;

public sealed class WatchlistUpdateDto : BaseDto
{
    public int UserId { get; set; }
    public int MovieId { get; set; }
}
