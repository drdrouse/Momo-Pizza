using Microsoft.AspNetCore.Mvc;
using Momo_Pizza.Models;

namespace Momo_Pizza.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add_User(string phone, string email, string password, string username)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = new User
                {
                    Phone = phone,
                    Email = email,
                    Password = password,
                    UserName = username
                };
                if (user != null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Json(true);
                }
                

            }
            return Json(false);
        }
    }
}
