using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Application.ViewModels;
using MediatR;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.CartItem.Queries
{
    public class GetCartItemByIDQueryHandler : IRequestHandler<GetCartItemByIDQuery, CartItemViewModel>
    {
        private readonly OnlineStoreDbContext _context;
        public GetCartItemByIDQueryHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<CartItemViewModel> Handle(GetCartItemByIDQuery request, CancellationToken cancellationToken)
        {
            var cartItem = await _context.CartItems.Where(ci => ci.ItemId == request.ItemId).Select(ci => new CartItemViewModel
            {
                ItemId = ci.ItemId,
                PId = ci.PId,
                TId = ci.TId.Value,
                Quantity = ci.Quantity.Value,
                Price = ci.Price.Value
            }).FirstOrDefaultAsync(cancellationToken);
            return cartItem;
        }
    }
}
