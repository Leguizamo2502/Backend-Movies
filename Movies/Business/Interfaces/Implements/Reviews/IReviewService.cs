using Business.Interfaces.BaseService;
using Entity.DTOs.Reviews.Create;
using Entity.DTOs.Reviews.Select;
using Entity.DTOs.Reviews.Update;

namespace Business.Interfaces.Implements.Reviews
{
    public interface IReviewService : IBaseBusiness<ReviewSelectDto,ReviewCreateDto,ReviewUpdateDto>
    {
    }
}
