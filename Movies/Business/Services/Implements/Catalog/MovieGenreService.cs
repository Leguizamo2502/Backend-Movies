using Business.Interfaces.Implements.Catalog;
using Business.Services.BaseService;
using Data.Interfaces.DataGeneric;
using Data.Interfaces.Implements.Catalog;
using Entity.Domain.Models.Implements.Catalog;
using Entity.DTOs.Catalog.MovieGenre.Create;
using Entity.DTOs.Catalog.MovieGenre.Select;
using Entity.DTOs.Catalog.MovieGenre.Update;
using Entity.DTOs.Talent.MovieActor.Select;
using MapsterMapper;
using Utilities.Business;

namespace Business.Services.Implements.Catalog.Implements
{
    public class MovieGenreService : BaseBusiness<MovieGenre, MovieGenreSelectDto, MovieGenreCreateDto, MovieGenreUpdateDto>, IMovieGenreService
    {
        private readonly IMovieGenreRepository _movieGenreRepository;
        public MovieGenreService(IMapper mapper, IDataGeneric<MovieGenre> data, IMovieGenreRepository movieGenreRepository) : base(mapper, data)
        {
            _movieGenreRepository = movieGenreRepository;
        }

        public override async Task<IEnumerable<MovieGenreSelectDto>> GetAllAsync()
        {
            try
            {
                var entities = await _movieGenreRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<MovieGenreSelectDto>>(entities);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al obtener todos los registros.", ex);
            }
        }

        public override async Task<MovieGenreSelectDto?> GetByIdAsync(int id)
        {
            try
            {
                BusinessValidationHelper.ThrowIfZeroOrLess(id, "El ID debe ser mayor que cero.");

                var entity = await _movieGenreRepository.GetByIdAsync(id);
                return entity == null ? default : _mapper.Map<MovieGenreSelectDto>(entity);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error al obtener el registro con ID {id}.", ex);
            }
        }

    }
    
}
