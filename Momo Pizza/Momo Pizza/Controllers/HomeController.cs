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
                User user = db.Users.Where(email => email.Email == authorized.Login).FirstOrDefault();
                if (authorized != null)
                {
                    db.Authorizeds.Remove(authorized);
                    db.SaveChanges();
                    Add_Log(user.UserName);
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
        private void Add_Log(string Name)
        {
            string path = "Loggin/autorization.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLineAsync($"Пользователь '{Name}' вышел из аккаунта.");
            }
        }
    }
}
