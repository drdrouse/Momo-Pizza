using Microsoft.AspNetCore.Mvc;

namespace Momo_Pizza.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
