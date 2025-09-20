using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Order.Command
{
    public class CreateOrderCommandHandler :IRequestHandler<CreateOrderCommand, int>
    {
        private readonly OnlineStoreDbContext _context;
        public CreateOrderCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = new Domain.Entities.Order
            {
                UId = command.UId,
                TotalPrice = command.TotalPrice,
                Paid = command.Paid,
                Date = command.Date,
                Status = command.Status,
                TId = command.TId
            };
            await _context.AddAsync(order,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return order.OId;
        }
    }
}
