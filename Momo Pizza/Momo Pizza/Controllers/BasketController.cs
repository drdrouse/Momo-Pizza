using Microsoft.AspNetCore.Mvc;

namespace Momo_Pizza.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
