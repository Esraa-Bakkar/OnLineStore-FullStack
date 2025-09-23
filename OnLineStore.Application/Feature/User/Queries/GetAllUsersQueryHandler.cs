using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Application.Feature.User.Queries;
using OnLineStore.Application.ViewModels;
using OnLineStore.Domain.Entities;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public GetAllUsersQueryHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userManager.Users
            .Select(u => new UserViewModel
            {
                Id = u.Id,
                Name = u.UserName,
                Email = u.Email,
                Phone = u.PhoneNumber,
                Address = u.Address
            })
            .ToListAsync(cancellationToken);

        return users;
    }
}
