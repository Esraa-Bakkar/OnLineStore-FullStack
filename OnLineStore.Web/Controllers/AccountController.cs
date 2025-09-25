using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnLineStore.Application.Feature.Cart.Command;
using OnLineStore.Application.ViewModels;
using OnLineStore.Domain.Entities;
using System.Threading.Tasks;

namespace OnLineStore.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mediator = mediator;
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
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
            var createCartCommand = new CreateCartCommand
            {
                UserId = user.Id,
                Date = DateOnly.FromDateTime(DateTime.Now) 
            };

            await _mediator.Send(createCartCommand);
            await _userManager.AddToRoleAsync(user, "Customer");
            return RedirectToAction("Login");
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync(); 
            return RedirectToAction("Index", "Home");
        }

       
    }
}