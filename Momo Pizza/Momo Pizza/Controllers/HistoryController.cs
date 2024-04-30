using Microsoft.AspNetCore.Mvc;
using Momo_Pizza.Models;

namespace Momo_Pizza.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Confirm(int id_history)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.Where(id => id.UserId == db.Authorizeds.ToList().FirstOrDefault().User_id).FirstOrDefault();
                Basket basket = db.Baskets.Where(id => id.User_ID == user.UserId).FirstOrDefault();
                foreach (Bought boug in db.Boughts.Where(his_id => his_id.Id_History == id_history))
                {
                    Pizza pizza = db.Pizzas.Where(id => id.PizzaId == boug.Id_Pizza).FirstOrDefault();
                    Order order = new Order()
                    {
                        Id_Basket = basket.BasketId,
                        Basket = basket,
                        Id_Pizza = pizza.PizzaId,
                        Pizza = pizza,
                        Count = boug.Count
                    };

                    db.Orders.Add(order);
                    
                    db.SaveChanges();
                }
                Add_Log("Loggin/history.txt", $"Заказ №{id_history}, добавлен в корзину. Дата: {DateTime.Now}");
                return Json(true);
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
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLineAsync(text);
            }
        }
    }
}
