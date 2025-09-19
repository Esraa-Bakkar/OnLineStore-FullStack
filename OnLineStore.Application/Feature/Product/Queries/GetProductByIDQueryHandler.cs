using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnLineStore.Application.ViewModels;
using MediatR;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Product.Queries
{
  public  class GetProductByIDQueryHandler : IRequestHandler<GetProductByIDQuery, ProductViewModel>

    {
        private readonly OnlineStoreDbContext _context;
        public GetProductByIDQueryHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public Task <ProductViewModel> Handle (GetProductByIDQuery request,CancellationToken cancellationToken)
            
        {
            var Product = _context.Products.Where(p=>p.PId==request.Id).Select(p => new ProductViewModel
            {
                PId = p.PId,
                    PName = p.PName,
                    Price = p.Price,
                ImgePath = p.ImgePath,
                CId = p.CId


            }).FirstOrDefault();
            return Task.FromResult(Product);
        }
    }

}
