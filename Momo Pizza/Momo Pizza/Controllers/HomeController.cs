using Microsoft.AspNetCore.Mvc;
using Momo_Pizza.Models;
using System.Diagnostics;

namespace Momo_Pizza.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Exite()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Authorized authorized = db.Authorizeds.FirstOrDefault();
                if (authorized != null)
                {
                    db.Authorizeds.Remove(authorized);
                    db.SaveChanges();
                    return Json(true);
                }
            }
            return Json(false);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
