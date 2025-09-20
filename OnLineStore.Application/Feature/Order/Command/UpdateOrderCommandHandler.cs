using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnLineStore.Application.ViewModels;
using OnLineStore.Infrastructure.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnLineStore.Application.Feature.Order.Command
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderViewModel>
    {
        private readonly OnlineStoreDbContext _context;
        public UpdateOrderCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }


        public async Task<OrderViewModel> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FindAsync(command.OrderId);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            order.UId = command.UId;
            order.TotalPrice = command.TotalPrice;
            order.Paid = command.Paid;
            order.Date = command.Date;
            order.Status = command.Status;
            order.TId = command.TId;

            await _context.SaveChangesAsync(cancellationToken);

            return new OrderViewModel
            {
                OId = order.OId,
                UId = order.UId,
                TotalPrice = order.TotalPrice,
                Paid = order.Paid,
                Date = order.Date,
                Status = order.Status,
                TId = order.TId

            };
        }
    }
}
