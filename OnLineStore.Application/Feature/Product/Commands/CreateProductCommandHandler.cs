using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnLineStore.Application.ViewModels;
using MediatR;
using OnLineStore.Infrastructure.Data;
using OnLineStore.Domain.Entities;


namespace OnLineStore.Application.Feature.Product.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductViewModel>
    {
        private readonly OnlineStoreDbContext _context;
        public CreateProductCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<ProductViewModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product  
            {
               
                PName = request.PName,
                Price = request.Price,
                CId = request.CId



            };
            _context.Products.Add(product);
            await  _context.SaveChangesAsync(cancellationToken);
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
