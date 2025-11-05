using Entity.DTOs.Base;

namespace Entity.DTOs.Watchlists.Update
{
    public class WatchlistUpdateDto : BaseDto
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
