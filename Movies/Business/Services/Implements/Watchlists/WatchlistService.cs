using Business.Interfaces.Implements.Watchlists;
using Business.Services.BaseService;
using Data.Interfaces.DataGeneric;
using Data.Interfaces.Implements.Watchlists;
using Entity.Domain.Models.Implements.Watchlists;
using Entity.DTOs.Catalog.MovieGenre.Select;
using Entity.DTOs.Watchlists.Create;
using Entity.DTOs.Watchlists.Select;
using Entity.DTOs.Watchlists.Update;
using MapsterMapper;
using Utilities.Business;

namespace Business.Services.Implements.Watchlists
{
    public class WatchlistService : BaseBusiness<Watchlist, WatchlistSelectDto, WatchlistCreateDto, WatchlistUpdateDto>, IWacthlistService
    {
        private readonly IWatchlistRepository _watchlistRepository;
        public WatchlistService(IMapper mapper, IDataGeneric<Watchlist> data, IWatchlistRepository watchlistRepository) : base(mapper, data)
        {
            _watchlistRepository = watchlistRepository;
        }


        public override async Task<IEnumerable<WatchlistSelectDto>> GetAllAsync()
        {
            try
            {
                var entities = await _watchlistRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<WatchlistSelectDto>>(entities);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al obtener todos los registros.", ex);
            }
        }

        public override async Task<WatchlistSelectDto?> GetByIdAsync(int id)
        {
            try
            {
                BusinessValidationHelper.ThrowIfZeroOrLess(id, "El ID debe ser mayor que cero.");

                var entity = await _watchlistRepository.GetByIdAsync(id);
                return entity == null ? default : _mapper.Map<WatchlistSelectDto>(entity);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error al obtener el registro con ID {id}.", ex);
            }
        }

    }
}
