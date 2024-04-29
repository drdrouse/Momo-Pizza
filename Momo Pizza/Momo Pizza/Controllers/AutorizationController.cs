using Microsoft.AspNetCore.Mvc;
using Momo_Pizza.Models;

namespace Momo_Pizza.Controllers
{
    public class AutorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.Where(p => p.Email == email && p.Password==password).FirstOrDefault();
                if (user != null)
                {
                    Authorized authorized = new Authorized
                    {
                        Login = email,
                        Password = password,
                        User_id = user.UserId,
                    };
                    db.Authorizeds.Add(authorized);
                    db.SaveChanges();
                    Add_Log(user.UserName);
                    return Json(true);
                }
            }
            return Json(false); 
        }

        private void Add_Log(string Name)
        {
            string path = "Loggin/autorization.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLineAsync($"Пользователь '{Name}' авторизировался.");
            }
        }
    }
}
