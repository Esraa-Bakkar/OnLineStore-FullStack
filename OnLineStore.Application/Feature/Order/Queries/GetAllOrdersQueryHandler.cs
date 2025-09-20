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
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery , IEnumerable<OrderViewModel>>
    {
        private readonly OnlineStoreDbContext _context;
        public GetAllOrdersQueryHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderViewModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var Orders = await _context.Orders.Select(x => new OrderViewModel
            {
                OId = x.OId,
                UId = x.UId,
                TotalPrice = x.TotalPrice,
                Paid = x.Paid,
                Date = x.Date,
                Status = x.Status,
                TId = x.TId
            }).ToListAsync();

            return Orders;



        }
    }
}
