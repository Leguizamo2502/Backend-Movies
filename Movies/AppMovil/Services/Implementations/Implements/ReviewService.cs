using AppMovil.Models.Implements.Review;
using AppMovil.Services.Abstractions.Implements;
using AppMovil.Services.Http;
using AppMovil.Services.Implementations.Generic;

namespace AppMovil.Services.Implementations.Implements;

public sealed class ReviewService : GenericService<ReviewSelectDto, ReviewCreateDto, ReviewUpdateDto>, IReviewService
{
    public ReviewService(ApiClient api) : base(api, "Review")
    {
    }
}
