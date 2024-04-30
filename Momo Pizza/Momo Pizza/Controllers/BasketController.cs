using Microsoft.AspNetCore.Mvc;
using Momo_Pizza.Models;
using NuGet.Configuration;
using System.Security.Cryptography;

namespace Momo_Pizza.Controllers
{
    public class BasketController : Controller
    {
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
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Confirm()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.Where(id => id.UserId == db.Authorizeds.ToList().FirstOrDefault().User_id).FirstOrDefault();
                Basket basket = db.Baskets.Where(id => id.User_ID == user.UserId).FirstOrDefault();
                CreateHistory(user);
                foreach (Order ord in db.Orders.Where(id => id.Id_Basket == basket.BasketId))
                {
                    AddBoughts(ord);
                    if (ord != null)
                    {
                        Add_Log("Loggin/basket.txt", $"Пользователь '{user.UserName}'. " +
                            $"Оплатил заказ №{ord.OrderId}. Дата: {DateTime.Now}");
                        db.Orders.Remove(ord);
                        db.SaveChanges();                        
                    }
                }                
                return Json(true);
            }
        }
        private void AddBoughts(Order ord)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                History history = db.Histories.ToList().LastOrDefault();
                Order order = db.Orders.Where(id => id==ord).FirstOrDefault();
                Pizza pizza = db.Pizzas.Where(id=> id.PizzaId==ord.Id_Pizza).FirstOrDefault();
                Bought bought = new Bought()
                {
                    Id_History = history.HistoryId,
                    History = history,
                    Id_Pizza = pizza.PizzaId,
                    Pizza = pizza,
                    Count = order.Count
                };
                db.Boughts.Add(bought);
                Add_Log("Loggin/history.txt", $"В историю №{history.HistoryId}, добавлена пицца {pizza.Name}. " +
                    $"Дата: {DateTime.Now}");
                db.SaveChanges();
            }
        }
        private void CreateHistory(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user_ = db.Users.Where(id => id==user).FirstOrDefault();
                History history = new History
                {
                    User_ID = user_.UserId,
                    User = user_
                };
                db.Histories.Add(history);                
                db.SaveChanges();

            }
        }
        [HttpPost]
        public void UpdateCountPizza_Plus(int orderID)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Order update_order = db.Orders.Where(id => id.OrderId == orderID).FirstOrDefault();
                if ((update_order != null) && (update_order.Count<99))
                {
                    update_order.Count += 1;
                    db.SaveChanges();
                    Add_Log("Loggin/basket.txt", $"В заказе №{update_order.OrderId}. " +
                            $"Изменено количество пицц c {update_order.Count-1} => {update_order.Count}. " +
                            $"Дата: {DateTime.Now}");
                }
            }
        }

        [HttpPost]
        public void UpdateCountPizza_Minus(int orderID)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Order update_order = db.Orders.Where(id => id.OrderId == orderID).FirstOrDefault();
                if ((update_order != null) && (update_order.Count > 1))
                {
                    update_order.Count -= 1;
                    Add_Log("Loggin/basket.txt", $"В заказе №{update_order.OrderId}. " +
                            $"Изменено количество пицц c {update_order.Count + 1} => {update_order.Count}. " +
                            $"Дата: {DateTime.Now}");
                    db.SaveChanges();
                }
            }
        }

        [HttpPost]
        public void Delete_Order(int orderID)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Order delete_order = db.Orders.Where(id => id.OrderId == orderID).FirstOrDefault();
                Pizza pizza = db.Pizzas.Where(id => id.PizzaId == delete_order.Id_Pizza).FirstOrDefault();
                if (pizza.Name == "Пицца по твоим правилам")
                {
                    db.Pizzas.Remove(pizza);
                    db.SaveChanges();
                }
                else if (delete_order != null)
                {
                    db.Orders.Remove(delete_order);
                    Add_Log("Loggin/basket.txt", $"Из корзины №{delete_order.Id_Basket}, удалена пицца " +
                        $"{pizza.Name}. Дата: {DateTime.Now}");
                    db.SaveChanges();
                }
            }
        }
    }
}
