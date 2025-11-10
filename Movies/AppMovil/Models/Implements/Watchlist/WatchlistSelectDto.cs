using AppMovil.Models.Base;

namespace AppMovil.Models.Implements.Watchlist;

public sealed class WatchlistSelectDto : BaseDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public int MovieId { get; set; }
    public string Title { get; set; } = string.Empty;
}
