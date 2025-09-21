using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Review.Command
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, int>
    {
        private readonly OnlineStoreDbContext _context;
        public CreateReviewCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateReviewCommand command, CancellationToken cancellationToken)
        {
            var review = new Domain.Entities.Review
            {
                UId = command.UId,
                PId = command.PId,
                Comment = command.Comment,
                Rating = command.Rating
            };
            await _context.Reviews.AddAsync(review, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return review.RId;
        }
    }
}
