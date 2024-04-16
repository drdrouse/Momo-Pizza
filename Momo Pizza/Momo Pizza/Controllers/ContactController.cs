using Microsoft.AspNetCore.Mvc;

namespace Momo_Pizza.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
