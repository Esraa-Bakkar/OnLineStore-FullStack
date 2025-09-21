using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Application.ViewModels;
using MediatR;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Cart.Command
{
 public   class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, CartViewModel>
    {
        private readonly OnlineStoreDbContext _context;
        public UpdateCartCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<CartViewModel> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _context.Carts.FindAsync(new object[] { request.Id }, cancellationToken);
            if (cart == null)
            {
                throw new KeyNotFoundException($"Cart with Id {request.Id} not found.");
            }
            cart.UId = request.UserId;
            cart.Date = request.Date;
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return new CartViewModel
            {
                Id = cart.TId,
                UserId = cart.UId,
                Date = cart.Date
            };
        }
    }
}
