using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Order.Command
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly OnlineStoreDbContext _context;
        public DeleteOrderCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FindAsync(command.OrderId);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            _context.Orders.Remove(order);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
