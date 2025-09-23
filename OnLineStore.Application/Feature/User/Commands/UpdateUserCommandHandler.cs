using MediatR;
using Microsoft.AspNetCore.Identity;
using OnLineStore.Application.ViewModels;
using OnLineStore.Domain.Entities;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserViewModel>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public UpdateUserCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id);
        if (user == null) throw new Exception("User not found");

        user.UserName = request.Name;
        user.Email = request.Email;
        user.PhoneNumber = request.Phone;
        user.Address = request.Address;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded) throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

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
