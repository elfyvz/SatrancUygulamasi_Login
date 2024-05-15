using Microsoft.AspNetCore.Mvc;

namespace SatrancUygulamasi.Controllers
{
    public class UserAuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
