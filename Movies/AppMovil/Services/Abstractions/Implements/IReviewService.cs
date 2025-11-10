using AppMovil.Models.Implements.Review;
using AppMovil.Services.Abstractions.Generic;

namespace AppMovil.Services.Abstractions.Implements;

public interface IReviewService : IGenericService<ReviewSelectDto, ReviewCreateDto, ReviewUpdateDto>
{
}
