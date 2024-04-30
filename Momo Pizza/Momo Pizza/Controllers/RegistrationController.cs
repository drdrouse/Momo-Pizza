using Microsoft.AspNetCore.Mvc;
using Momo_Pizza.Models;
using NuGet.ContentModel;
using System.Text;

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
                User user_yet = db.Users.Where(email_ => email_.Email == email).FirstOrDefault();

                User user = new User
                {
                    Phone = phone,
                    Email = email,
                    Password = password,
                    UserName = username
                };
                if ((user != null) && (user_yet == null))
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    Add_Basket(email);
                    Add_Log("Loggin/user.txt", $"Новый пользователь под ником \"{username}\" зрегистрирован. Дата: {DateTime.Now}");
                    return Json(true);
                }
                
                

            }
            return Json(false);
        }
        
        [HttpPost]
        public void Create_Log(string path, string text)
        {
            Add_Log(path, text);
        }
        public void Add_Basket(string email)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.Where(email_ => email_.Email==email).FirstOrDefault();
                Basket basket = new Basket()
                {
                    User_ID = user.UserId,
                    User = user,
                };

                if (basket != null)
                {
                    db.Baskets.Add(basket);
                    db.SaveChanges();
                }
            }
        }

        private void Add_Log(string path, string text)
        {
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
            while (true)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(path, true);
                    sw.WriteLineAsync(text);
                    sw.Close();
                    break;
                }
                catch
                {
                    Thread.Sleep(100);
                }
            }
            
        }
    }
}
