using System;
using MediatR;
using OnLineStore.Infrastructure.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

    namespace OnLineStore.Application.Feature.Order.Command
    {
        public class ConfirmPaymentCommandHandler : IRequestHandler<ConfirmPaymentCommand, bool>
        {
            private readonly OnlineStoreDbContext _context;

            public ConfirmPaymentCommandHandler(OnlineStoreDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(ConfirmPaymentCommand request, CancellationToken cancellationToken)
            {
                var order = await _context.Orders.FirstOrDefaultAsync(o => o.OId == request.OrderId, cancellationToken);

                if (order == null)
                    return false;

                
                order.Paid = true;
                order.Status = "P";  
                order.TotalPrice = request.Amount;

                _context.Orders.Update(order);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
        }
    }

