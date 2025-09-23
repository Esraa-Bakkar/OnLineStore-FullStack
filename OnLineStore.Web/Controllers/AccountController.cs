using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnLineStore.Application.ViewModels;
using OnLineStore.Domain.Entities;
using System.Threading.Tasks;

namespace OnLineStore.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                var result = await _signInManager.PasswordSignInAsync(
                    model.Username,
                    model.Password,
                    model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                   ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

           
            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync(); 
            return RedirectToAction("Index", "Home");
        }
    }
}