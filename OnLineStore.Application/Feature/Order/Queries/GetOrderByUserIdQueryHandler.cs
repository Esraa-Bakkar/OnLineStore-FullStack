using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Application.ViewModels;
using MediatR;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Order.Queries
{
    public class GetOrderByUserIdQueryHandler : IRequestHandler<GetOrderByUserIdQuery, OrderViewModel>
    {
        private readonly OnlineStoreDbContext _context;

        public GetOrderByUserIdQueryHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public async Task<OrderViewModel> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Where(o => o.UId == request.UserId)
                .Include(o => o.TIdNavigation)
                    .ThenInclude(t => t.CartItems)
                        .ThenInclude(ci => ci.PIdNavigation)
                .OrderByDescending(o => o.Date) 
                .FirstOrDefaultAsync(cancellationToken);

            if (order == null)
                return null;

            return new OrderViewModel
            {
                OId = order.OId,
                UId = order.UId,
                TotalPrice = order.TotalPrice,
                Date = order.Date,
                Status = order.Status,
                Paid = order.Paid,
                CartItems = order.TIdNavigation?.CartItems.Select(ci => new CartItemViewModel
                {
                    ProductName = ci.PIdNavigation.PName,
                    ImagPath = ci.PIdNavigation.ImgePath,
                    Quantity = ci.Quantity,
                    Price = ci.Price
                }).ToList() ?? new List<CartItemViewModel>()
            };
        }
    }
}
