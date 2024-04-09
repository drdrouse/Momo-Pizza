using Microsoft.AspNetCore.Mvc;

namespace Momo_Pizza.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
