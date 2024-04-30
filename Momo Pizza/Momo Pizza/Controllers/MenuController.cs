using Microsoft.AspNetCore.Mvc;
using Momo_Pizza.Models;

namespace Momo_Pizza.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add_Order(int pizzaID, int Aut_Id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Authorized authorized = db.Authorizeds.Where(id => id.AuthorizedId == Aut_Id).FirstOrDefault();
                Pizza pizza = db.Pizzas.Where(id => id.PizzaId == pizzaID).FirstOrDefault();
                Basket basket = db.Baskets.Where(id => id.User_ID == authorized.User_id).FirstOrDefault();
                Order yet_Order = db.Orders.Where(id=>id.Id_Pizza == pizzaID && id.Id_Basket==basket.BasketId).FirstOrDefault();

                Order order = new Order
                {
                    Id_Basket = basket.BasketId,
                    Basket = basket,
                    Id_Pizza = pizza.PizzaId,
                    Pizza = pizza,
                    Count = 1
                };
                if ((order != null) && (yet_Order == null))
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    Add_Log("Loggin/order.txt", $"В корзину {basket.BasketId}, добавлена пицца №{pizza.PizzaId}. Дата: {DateTime.Now}");
                    return Json(true);
                }
                
            }
            return Json(false);
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
