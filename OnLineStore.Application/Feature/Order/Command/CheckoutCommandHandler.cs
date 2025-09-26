using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Infrastructure.Data;
using OnLineStore.Domain.Entities;


namespace OnLineStore.Application.Feature.Order.Command
{

        public class CheckoutCommandHandler : IRequestHandler<CheckoutCommand, int>
        {
            private readonly OnlineStoreDbContext _context;

            public CheckoutCommandHandler(OnlineStoreDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CheckoutCommand request, CancellationToken cancellationToken)
            {
            
            var cart = await _context.Carts
                 .Include(c => c.CartItems)
                        .ThenInclude(ci => ci.PIdNavigation)
                      .FirstOrDefaultAsync(c =>
                          c.UId == request.UserId &&
                   !_context.Orders.Any(o => o.TId == c.TId), 
                         cancellationToken);


            if (cart == null || !cart.CartItems.Any())
                    throw new Exception("Cart is empty or does not exist.");

              
                var totalPrice = cart.CartItems.Sum(ci => ci.Price * ci.Quantity);

                
                var order = new  Domain.Entities.Order
                {
                    UId = request.UserId,
                    TotalPrice = totalPrice,
                    Paid = false, 
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    Status = "P",
                    TId = cart.TId  
                };

                await _context.Orders.AddAsync(order, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return order.OId;
            }
        }
    }


