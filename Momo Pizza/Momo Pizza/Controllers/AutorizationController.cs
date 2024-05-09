using Azure.Core.Serialization;
using Microsoft.AspNetCore.Mvc;
using Momo_Pizza.Models;
using Newtonsoft.Json;
using System.Text.Json;

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
                    return Json(user.UserId);
                }
            }
            return Json(null); 
        }
        public bool isAuthorize(string email, string password)
        {
            object check = (Login(email, password) as JsonResult)?.Value;
            if (check != null)
                return true;
            else return false;
        }
        private void Add_Log(Guid id)
        {
            string path = "Loggin/user.txt";
            int count_log = 0;
            string log;
            StreamReader sr = new StreamReader(path, true);

            while ((log = sr.ReadLine()) != null)
            {
                count_log++;
            }
            sr.Close();
            if (count_log >= 50)
            {
                FileStream fs = new FileStream(path, FileMode.Truncate);
                fs.Close();
            }
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLineAsync($"Пользователь '{id}' авторизировался. Дата: {DateTime.Now}");
            }
        }

        [HttpPost]
        public IActionResult Add_Authoruze(string email, string password, Guid id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                Authorized authorized = new Authorized
                {
                    Login = email,
                    Password = password,
                    User_id = id,
                };
                db.Authorizeds.Add(authorized);
                Add_Log(id);
                db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }
    }
}
