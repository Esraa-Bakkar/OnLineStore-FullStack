using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Review.Command
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Unit>
    {
        private readonly OnlineStoreDbContext _context;
        public DeleteReviewCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteReviewCommand command, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews.FindAsync(command.ReviewId);
            if (review == null)
            {
                throw new Exception("Review not found");
            }
             _context.Reviews.Remove(review);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        

        }
    }
}
