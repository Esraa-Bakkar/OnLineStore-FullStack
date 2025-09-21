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
    public class GetAllCartsQueryHandler : IRequestHandler<GetAllCartsQuery, IEnumerable<CartViewModel>>
    {
        private readonly OnlineStoreDbContext _context;
        public GetAllCartsQueryHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async  Task<IEnumerable<CartViewModel>> Handle(GetAllCartsQuery request, CancellationToken cancellationToken)
        {
           var cartsvw = await _context.Carts.Select(c => new CartViewModel
           {
               Id = c.TId,
               Date = c.Date,
               UserId = c.UId
           }).ToListAsync(cancellationToken);

            return cartsvw;
        }
    }
}
