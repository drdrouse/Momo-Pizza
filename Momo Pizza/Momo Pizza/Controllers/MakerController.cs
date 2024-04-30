using Microsoft.AspNetCore.Mvc;
using Momo_Pizza.Models;

namespace Momo_Pizza.Controllers
{
    public class MakerController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
        [HttpPost]
        public IActionResult AddPizza(int Price, string NameDough, string NameSauce, string[] NameIngredient)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.Where(id => id.UserId == db.Authorizeds.ToList().FirstOrDefault().User_id).FirstOrDefault();
                Dough dough = db.Doughs.Where(name => name.Name == NameDough).FirstOrDefault();
                Sauce sauce = db.Sauces.Where(name => name.Name_Sauce == NameSauce).FirstOrDefault();
                Pizza pizza = new Pizza()
                {
                    Name = "Пицца по твоим правилам",
                    Diameter = 30,
                    Price = Price,
                    Photo = "No_image.jpg",
                    Description = "Пицца, которую сделали вы сами.",
                    ID_Dough = dough.DoughId,
                    Dough = dough,
                    ID_Sauce = sauce.SauceId,
                    Sauces = sauce
                };
                if (pizza != null)
                {
                    db.Pizzas.Add(pizza);
                    db.SaveChanges();
                }
                AddOrder(pizza);
                AddFilling(pizza, NameIngredient);
                Add_Log("Loggin/maker.txt", $"Пользователь \"{user.UserName}\", создал пиццу в \"Пицца-Мейкер\"");
                return Json(true);
            }

        }

        public void AddFilling(Pizza pizza_created, string[] NameIngredient)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                for (int i = 0; i < NameIngredient.Length; i++)
                {
                    Ingredient ingredient = db.Ingredients.Where(name => name.Name == NameIngredient[i]).FirstOrDefault();
                    Pizza pizza = db.Pizzas.Where(id => id == pizza_created).FirstOrDefault();
                    Filling filling = new Filling()
                    {
                        Id_Pizza = pizza.PizzaId,
                        Pizza = pizza,
                        IndredientID = ingredient.IngredientId,
                        Ingredient = ingredient
                    };
                    if (filling != null)
                    {
                        db.Fillings.Add(filling);
                        db.SaveChanges();
                    }
                }
            }
        }
        public void AddOrder(Pizza pizza_created)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Authorized authorized = db.Authorizeds.ToList().FirstOrDefault();
                Basket basket = db.Baskets.Where(id => id.User_ID == authorized.User_id).FirstOrDefault();
                Pizza pizza = db.Pizzas.Where(id => id == pizza_created).FirstOrDefault();
                Order order = new Order
                {
                    Id_Basket = basket.BasketId,
                    Basket = basket,
                    Id_Pizza = pizza.PizzaId,
                    Pizza = pizza,
                    Count = 1
                };
                if ((order != null))
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    Add_Log("Loggin/order.txt", $"В корзину {basket.BasketId}, добавлена пицца №{pizza.PizzaId}. Дата: {DateTime.Now}");
                }

            }
        }
    }
}
