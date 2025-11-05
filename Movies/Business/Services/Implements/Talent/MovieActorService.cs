using Business.Interfaces.Implements.Talent;
using Business.Services.BaseService;
using Data.Interfaces.DataGeneric;
using Data.Interfaces.Implements.Talent;
using Entity.Domain.Models.Implements.Talent;
using Entity.DTOs.Talent.MovieActor.Create;
using Entity.DTOs.Talent.MovieActor.Select;
using Entity.DTOs.Talent.MovieActor.Update;
using MapsterMapper;
using Utilities.Business;

namespace Business.Services.Implements.Talent
{
    public class MovieActorService : BaseBusiness<MovieActor, MovieActorSelectDto, MovieActorCreateDto, MovieActorUpdatetDto>, IMovieActorService
    {
        private readonly IMovieActorRepository _movieActorRepository;
        public MovieActorService(IMapper mapper, IDataGeneric<MovieActor> data, IMovieActorRepository movieActorRepository) : base(mapper, data)
        {
            _movieActorRepository = movieActorRepository;
        }

        public override async Task<IEnumerable<MovieActorSelectDto>> GetAllAsync()
        {
            try
            {
                var entities = await _movieActorRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<MovieActorSelectDto>>(entities);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al obtener todos los registros.", ex);
            }
        }

        public override async Task<MovieActorSelectDto?> GetByIdAsync(int id)
        {
            try
            {
                BusinessValidationHelper.ThrowIfZeroOrLess(id, "El ID debe ser mayor que cero.");

                var entity = await _movieActorRepository.GetByIdAsync(id);
                return entity == null ? default : _mapper.Map<MovieActorSelectDto>(entity);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error al obtener el registro con ID {id}.", ex);
            }
        }
    }
}
