using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnLineStore.Infrastructure.Data;
using MediatR;
using OnLineStore.Application.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace OnLineStore.Application.Feature.Product.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductViewModel>>
    {
        private readonly OnlineStoreDbContext _context;
        public GetAllProductsQueryHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }


        public Task<IEnumerable<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var Products =  _context.Products.AsNoTracking().ToListAsync(cancellationToken);
            var ProductViewModel = Products.Result.Select(p => new ProductViewModel
            {
                PId = p.PId,
                PName = p.PName,
                Price = p.Price,
                ImgePath = p.ImgePath
            });
            return Task.FromResult(ProductViewModel);

        }
    }
}
