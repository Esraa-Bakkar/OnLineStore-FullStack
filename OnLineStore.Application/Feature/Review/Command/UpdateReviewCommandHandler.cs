using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnLineStore.Application.ViewModels;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Review.Command
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, ReviewViewModel>
    {
        private readonly OnlineStoreDbContext _context;
        public UpdateReviewCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ReviewViewModel> Handle (UpdateReviewCommand command, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews.FindAsync(command.RId);
            if (review == null)
            {
                throw new Exception("Review not found");
            }
            review.UId = command.UId;
            review.PId = command.PId;
            review.Rating = command.Rating;
            review.Comment = command.Comment;

            _context.Reviews.Update(review);
            await _context.SaveChangesAsync(cancellationToken);

            return new ReviewViewModel
            {
                RId = review.RId,
                UId = review.UId,
                PId = review.PId,
                Rating = review.Rating,
                Comment = review.Comment

            };

        }
    }
}
