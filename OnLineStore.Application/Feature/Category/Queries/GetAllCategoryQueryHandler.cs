using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Application.ViewModels;
using OnLineStore.Infrastructure.Data;
namespace OnLineStore.Application.Feature.Category.Queries
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<CategoryViewModel>>
    {
        private readonly OnlineStoreDbContext _context;
        public GetAllCategoryQueryHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CategoryViewModel>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {

           var categories = await _context.Catagories.AsNoTracking().ToListAsync(cancellationToken);
            var categoriesViewModel = categories.Select(c => new CategoryViewModel
            {
                CId = c.CId,
                CName = c.CName,
                Description = c.Description
            });
            return categoriesViewModel;
        }

    }
}
