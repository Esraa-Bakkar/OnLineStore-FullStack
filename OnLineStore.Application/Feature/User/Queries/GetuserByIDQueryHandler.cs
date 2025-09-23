using MediatR;
using Microsoft.AspNetCore.Identity;
using OnLineStore.Application.ViewModels;
using OnLineStore.Domain.Entities;

public class GetUserByIdQueryHandler : IRequestHandler<GetuserByIDQuery, UserViewModel>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public GetUserByIdQueryHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserViewModel> Handle(GetuserByIDQuery request, CancellationToken cancellationToken)
    {
        var u = await _userManager.FindByIdAsync(request.Id);
        if (u == null) return null;

        return new UserViewModel
        {
            Id = u.Id,
            Name = u.UserName,
            Email = u.Email,
            Phone = u.PhoneNumber,
            Address = u.Address
        };
    }
}
