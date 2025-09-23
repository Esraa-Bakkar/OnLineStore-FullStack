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
   public class GetAllCartItemsQueryHandler : IRequestHandler<GetAllCartItemsQuery, IEnumerable<CartItemViewModel>>
    {
        private readonly OnlineStoreDbContext _context;
        public GetAllCartItemsQueryHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CartItemViewModel>> Handle(GetAllCartItemsQuery request, CancellationToken cancellationToken)
        {
            var cartItems = await _context.CartItems.Select(ci => new CartItemViewModel
            {
                ItemId = ci.ItemId,
                PId = ci.PId,
                TId = ci.TId.Value,
                Quantity = ci.Quantity.Value,
                Price = ci.Price.Value
            }).ToListAsync(cancellationToken);
            return cartItems;
        }
    }
}
