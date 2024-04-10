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
                    return Json(true);
                }
                
                

            }
            return Json(false);
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
    }
}
