using Microsoft.AspNetCore.Mvc;

namespace Momo_Pizza.Controllers
{
    public class MakerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
