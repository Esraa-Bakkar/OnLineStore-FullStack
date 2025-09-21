using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Application.ViewModels;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Review.Queries
{
    public class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQuery, IEnumerable<ReviewViewModel>>
    {
        private readonly OnlineStoreDbContext _context;
        public GetAllReviewQueryHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ReviewViewModel>> Handle(GetAllReviewQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _context.Reviews.Select(r => new ReviewViewModel
            {
                RId = r.RId,
                UId = r.UId,
                PId = r.PId,    
                Comment = r.Comment,
                Rating = r.Rating

            }).ToListAsync();
            return reviews;
        }
    }
}
