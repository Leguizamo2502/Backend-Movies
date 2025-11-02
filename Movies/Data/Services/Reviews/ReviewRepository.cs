using Data.Interfaces.Implements.Reviews;
using Data.Repository;
using Entity.Domain.Models.Implements.Reviews;
using Entity.Infrastructure.Contexs;

namespace Data.Services.Reviews
{
    public class ReviewRepository : DataGeneric<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
