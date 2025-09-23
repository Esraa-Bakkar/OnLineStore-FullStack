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
  public  class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, CartItemViewModel>
    {
        private readonly OnlineStoreDbContext _context;
        public CreateCartItemCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<CartItemViewModel> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = new Domain.Entities.CartItem
            {
                PId = request.PId,
                TId= request.TId,
                Quantity = request.Quantity,
                Price = request.Price
            };
             _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync(cancellationToken);
            return new CartItemViewModel
            {
              ItemId = cartItem.ItemId,
                PId = cartItem.PId,
                TId = cartItem.TId.Value,
                Quantity = cartItem.Quantity.Value,
                Price = cartItem.Price.Value
            };
        }
    }
}
