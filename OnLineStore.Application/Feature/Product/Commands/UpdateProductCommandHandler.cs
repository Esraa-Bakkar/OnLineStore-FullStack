using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OnLineStore.Application.ViewModels;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Product.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductViewModel>
    {
        private readonly OnlineStoreDbContext _context;

        public UpdateProductCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ProductViewModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(new object[] { request.Id },cancellationToken );
           
            if (product == null)
            {
                throw new Exception("Product not found");
            }

           
            product.PName = request.PName;
            product.Price = request.Price;
            product.CId = request.CId;
            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);

            return new ProductViewModel
            {
                PId = product.PId,
                PName = product.PName,
                Price = product.Price,
                CId = product.CId
            };
        }
    }
}
