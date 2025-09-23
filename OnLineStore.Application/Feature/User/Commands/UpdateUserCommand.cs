// UpdateUserCommand
using MediatR;
using OnLineStore.Application.ViewModels;

public class UpdateUserCommand : IRequest<UserViewModel>
{
    public string Id { get; set; }  
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
}
