using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Application.ViewModels;
using MediatR;
using OnLineStore.Infrastructure.Data;


namespace OnLineStore.Application.Feature.Cart.Queries
{
   public class GetCartByIDQueryHandler : IRequestHandler<GetCartByIDQuery, CartViewModel>
    {
        private readonly OnlineStoreDbContext _context;
        public GetCartByIDQueryHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<CartViewModel> Handle(GetCartByIDQuery request, CancellationToken cancellationToken)
        {
            var cartvw = await _context.Carts.Where(c=>c.TId==request.Id).Select(c =>new CartViewModel
            {
                Id = c.TId,
                Date = c.Date,
                UserId = c.UId
            }).FirstOrDefaultAsync(cancellationToken);
            if (cartvw == null)
            {
                throw new Exception($"Cart with ID {request.Id} not found.");
            }
            return cartvw;

        }
            
    }
}
