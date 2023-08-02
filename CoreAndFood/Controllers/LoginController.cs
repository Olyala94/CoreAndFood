using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
