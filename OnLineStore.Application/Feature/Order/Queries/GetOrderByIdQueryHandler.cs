using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Application.ViewModels;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Order.Queries
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderViewModel>
    {
        private readonly OnlineStoreDbContext _context;
        public GetOrderByIdQueryHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public async Task<OrderViewModel> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.
                Where(x => x.OId == query.OrderId).Include(x => x.TIdNavigation).ThenInclude
                (item => item.CartItems).ThenInclude(x => x.PIdNavigation).Select(c => new OrderViewModel
                {
                    OId = c.OId,
                    UId = c.UId,
                    TId = c.TId,
                    Date = c.Date,
                    CartItems = c.TIdNavigation.CartItems.Select(ci => new CartItemViewModel
                    {
                        ItemId = ci.ItemId,
                        PId = ci.PId,
                        ProductName = ci.PIdNavigation.PName,
                        ImagPath = ci.PIdNavigation.ImgePath,
                        Quantity = ci.Quantity,
                        Price = ci.Price
                        

                    }).ToList(),
                    TotalPrice = c.TIdNavigation.CartItems.Sum(i=>i.Quantity*i.Price)


                }).FirstOrDefaultAsync(cancellationToken);

            if (order == null) 
            {
                throw new Exception("Order not found");

            }
            return order;
        
        }
    }

}
