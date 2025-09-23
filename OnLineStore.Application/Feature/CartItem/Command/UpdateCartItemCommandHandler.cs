using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Application.ViewModels;
using MediatR;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.CartItem.Command
{
   public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand, CartItemViewModel>
    {
        private readonly OnlineStoreDbContext _context;
        public UpdateCartItemCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<CartItemViewModel> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = _context.CartItems.Where(a => a.ItemId == request.ItemId).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.PId = request.PId;
                cartItem.Quantity = request.Quantity;
                cartItem.Price = request.Price;
                await _context.SaveChangesAsync();
                return new CartItemViewModel
                {
                    ItemId = cartItem.ItemId,
                    PId = cartItem.PId,
                    Quantity = cartItem.Quantity.Value,
                    Price = cartItem.Price.Value
                };
            }
            else
            {
                return null;
            }
        }
    }
}
