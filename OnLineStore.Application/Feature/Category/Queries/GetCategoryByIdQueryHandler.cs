using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnLineStore.Application.ViewModels;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Category.Queries
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryViewModel>
    {
       private readonly OnlineStoreDbContext _context;

        public GetCategoryByIdQueryHandler(OnlineStoreDbContext context)
        {
            _context = context; 
        }

        public async Task<CategoryViewModel> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Catagories.FindAsync(request.CId);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            var categoryResult = new CategoryViewModel
            {
                CId = category.CId,
                CName = category.CName,
                Description = category.Description
            };
            return categoryResult;
        }
    }
}
