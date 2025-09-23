
namespace OnLineStore.Application.ViewModels;
public class UserViewModel
{
    public string Id { get; set; }       
    public string Name { get; set; }
    public string Email { get; set; }

    public string Phone { get; set; }
    public string Address { get; set; }

    public string Password { get; set; } = string.Empty;
}
