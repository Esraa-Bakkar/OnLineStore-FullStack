using OnLineStore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnLineStore.Application.ViewModels;
using MediatR;


namespace OnLineStore.Application.Feature.CartItem.Command
{
   public class DeleteCartItemCommandHandler: IRequestHandler<DeleteCartItemCommand, string>
    {
        private readonly OnlineStoreDbContext _context;
        public DeleteCartItemCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = await _context.CartItems.FindAsync(request.Id, cancellationToken);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
                return "Cart Item Deleted Successfully";
            }
            else
            {
                return "Cart Item Not Found";
            }
        }
    }
}
