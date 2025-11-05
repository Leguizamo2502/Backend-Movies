using Business.Interfaces.BaseService;
using Entity.DTOs.Watchlists.Create;
using Entity.DTOs.Watchlists.Select;
using Entity.DTOs.Watchlists.Update;

namespace Business.Interfaces.Implements.Watchlists
{
    public interface IWacthlistService : IBaseBusiness<WatchlistSelectDto,WatchlistCreateDto,WatchlistUpdateDto>
    {
    }
}
