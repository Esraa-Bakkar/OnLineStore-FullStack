using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Application.ViewModels;
using MediatR;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.User.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetuserByIDQuery, UserViewModel>
    {
        private readonly OnlineStoreDbContext _context;

        public GetUserByIdQueryHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public async Task<UserViewModel> Handle(GetuserByIDQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Where(u => u.UId == request.Id)
                .Select(u => new UserViewModel
                {
                    Id = u.UId,
                    Name = u.UName,
                    Email = u.Email,
                    Phone = u.Phone,
                    Address = u.Address
                })
                .FirstOrDefaultAsync(cancellationToken);

            return user;
        }
    }
}
