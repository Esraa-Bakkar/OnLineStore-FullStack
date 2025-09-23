using MediatR;
using Microsoft.AspNetCore.Identity;
using OnLineStore.Domain.Entities;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, string>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public DeleteUserCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id);
        if (user == null) return $"User with ID {request.Id} not found.";

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded) throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

        return $"User with ID {request.Id} has been deleted.";
    }
}
