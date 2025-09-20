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
                FirstOrDefaultAsync(x => x.OId == query.OrderId);

            if (order == null) 
            {
                throw new Exception("Order not found");

            }
            var orderViewModel = new OrderViewModel
            {
                OId = order.OId,
                UId = order.UId,
                TotalPrice = order.TotalPrice,
                Paid = order.Paid,
                Date = order.Date,
                Status = order.Status,
                TId = order.TId
            };
            return orderViewModel;
        
        }
    }

}
