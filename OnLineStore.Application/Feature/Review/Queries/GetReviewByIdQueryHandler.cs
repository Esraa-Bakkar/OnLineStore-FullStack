using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnLineStore.Application.ViewModels;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Review.Queries
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, ReviewViewModel>
    {
        private readonly OnlineStoreDbContext _context;
        public GetReviewByIdQueryHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<ReviewViewModel> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews.FindAsync(request.ReviewId);
            if (review == null)
            {
                throw new Exception("Review not found");
            }
            return new ReviewViewModel
            {
                RId = review.RId,
                UId = review.UId,
                PId = review.PId,
                Comment = review.Comment,
                Rating = review.Rating
            };
        }
    }
}
