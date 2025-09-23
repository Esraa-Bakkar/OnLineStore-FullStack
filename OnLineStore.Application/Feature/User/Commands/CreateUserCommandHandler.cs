using Microsoft.AspNetCore.Identity;
using MediatR;
using OnLineStore.Application.ViewModels;
using OnLineStore.Domain.Entities;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserViewModel>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public CreateUserCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            UserName = request.Name,
            Email = request.Email,
          
            PhoneNumber = request.Phone,
            Address = request.Address
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));
        }

        return new UserViewModel
        {
            Id = user.Id,
            Name = user.UserName,
            Email = user.Email,
            Phone = user.PhoneNumber,
            Address = user.Address
        };
    }
}
