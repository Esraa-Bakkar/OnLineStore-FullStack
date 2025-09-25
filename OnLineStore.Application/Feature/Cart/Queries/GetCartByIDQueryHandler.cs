using MediatR;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Application.ViewModels;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Cart.Queries
{
    public class GetCartByIDQueryHandler : IRequestHandler<GetCartByIDQuery, CartViewModel>
    {
        private readonly OnlineStoreDbContext _context;

        public GetCartByIDQueryHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public async Task<CartViewModel> Handle(GetCartByIDQuery request, CancellationToken cancellationToken)
        {

            var cartViewModel = await _context.Carts
      .Where(c => c.TId == request.Id)
      .Include(c => c.CartItems)                         
          .ThenInclude(item => item.PIdNavigation)       
      .Select(cart => new CartViewModel
      {
          Id = cart.TId,
          Date = cart.Date,
          UserId = cart.UId,

          Items = cart.CartItems.Select(item => new CartItemViewModel
          {
              ItemId = item.ItemId,
              PId = item.PId,
              ProductName = item.PIdNavigation.PName,     
              ImagPath = item.PIdNavigation.ImgePath,     
              Quantity = item.Quantity,
              Price = item.Price
          }).ToList(),
      })
      .FirstOrDefaultAsync(cancellationToken);


            if (cartViewModel == null)
            {
                throw new Exception($"Cart with ID {request.Id} not found.");
            }

            return cartViewModel;
        }
    }
}