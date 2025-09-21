using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Application.ViewModels;
using MediatR;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Cart.Command
{
  public  class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, string>
    {
        private readonly OnlineStoreDbContext _context;
        public DeleteCartCommandHandler(OnlineStoreDbContext context) 
        {
            _context = context;
        }
        public async Task<string> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _context.Carts.FindAsync(new object[] { request.Id }, cancellationToken);
            if (cart == null)
            {
                return "Cart not found";
            }
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return "Cart deleted successfully";
        }
    }

}
