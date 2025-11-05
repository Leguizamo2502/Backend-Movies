using Entity.DTOs.Base;

namespace Entity.DTOs.Watchlists.Select
{
    public class WatchlistSelectDto : BaseDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
    }
}
