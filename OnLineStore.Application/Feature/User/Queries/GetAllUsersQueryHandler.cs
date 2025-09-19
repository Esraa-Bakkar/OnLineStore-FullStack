using MediatR;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Application.Feature.User.Queries;
using OnLineStore.Application.ViewModels;
using OnLineStore.Infrastructure.Data;


public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
{
    private readonly OnlineStoreDbContext _context;

    public GetAllUsersQueryHandler(OnlineStoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _context.Users
            .Select(u => new UserViewModel
            {
                Id = u.UId,
                Name = u.UName,
                Email = u.Email,
                Phone = u.Phone,
                Address = u.Address
            })
            .ToListAsync(cancellationToken);

        return users;
    }
}
