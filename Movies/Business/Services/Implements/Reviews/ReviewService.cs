using Business.Interfaces.Implements.Reviews;
using Business.Services.BaseService;
using Data.Interfaces.Implements.Reviews;
using Entity.Domain.Models.Implements.Reviews;
using Entity.DTOs.Reviews.Create;
using Entity.DTOs.Reviews.Select;
using Entity.DTOs.Reviews.Update;
using MapsterMapper;
using Utilities.Business;

namespace Business.Services.Implements.Reviews
{
    public class ReviewService : BaseBusiness<Review, ReviewSelectDto, ReviewCreateDto, ReviewUpdateDto>,IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IMapper mapper, Data.Interfaces.DataGeneric.IDataGeneric<Review> data, IReviewRepository reviewRepository) : base(mapper, data)
        {
            _reviewRepository = reviewRepository;
        }

        public override async Task<IEnumerable<ReviewSelectDto>> GetAllAsync()
        {
            try
            {
                var entities = await _reviewRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<ReviewSelectDto>>(entities);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al obtener todos los registros.", ex);
            }
        }

        public override async Task<ReviewSelectDto?> GetByIdAsync(int id)
        {
            try
            {
                BusinessValidationHelper.ThrowIfZeroOrLess(id, "El ID debe ser mayor que cero.");

                var entity = await _reviewRepository.GetByIdAsync(id);
                return entity == null ? default : _mapper.Map<ReviewSelectDto>(entity);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error al obtener el registro con ID {id}.", ex);
            }
        }

    }
}
