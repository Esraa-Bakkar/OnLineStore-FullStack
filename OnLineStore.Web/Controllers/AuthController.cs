using Microsoft.AspNetCore.Mvc;

namespace OnLineStore.Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
