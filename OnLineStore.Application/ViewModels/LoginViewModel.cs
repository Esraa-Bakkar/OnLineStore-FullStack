using System.ComponentModel.DataAnnotations;

namespace OnLineStore.Application.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "User Name is required")]
        [Display(Name = "User Name")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}