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
  public  class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, CartViewModel>
    {
        private readonly OnlineStoreDbContext _context;
        public CreateCartCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<CartViewModel> Handle (CreateCartCommand request, CancellationToken cancellationToken)
        {
           
            var cart = new OnLineStore.Domain.Entities.Cart
            {
                UId = request.UserId,
                Date = request.Date
            };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return new CartViewModel
            {
                Id = cart.TId,
                UserId = cart.UId ,
                Date = cart.Date 
            };
        }
    }
}
