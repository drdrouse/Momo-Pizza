using Microsoft.AspNetCore.Mvc;

namespace Momo_Pizza.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
