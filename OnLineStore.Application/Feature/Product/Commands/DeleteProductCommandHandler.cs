using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnLineStore.Application.ViewModels;
using MediatR;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Product.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, String>
    {
        private readonly OnlineStoreDbContext _context;
        public DeleteProductCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<String> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Products.Find(request.Id);
            if (product == null)
            {
                return $"Product not found ";
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return $"product deleted ";
        }
    }
}
