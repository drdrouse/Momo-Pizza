using Microsoft.AspNetCore.Mvc;
using Momo_Pizza.Models;
using System.Diagnostics;

namespace Momo_Pizza.Controllers
{
    public class GetDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public bool AddData(string name, string type_flour, double calories, int price)
        {
            Dough dough = new Dough()
            {
                Name = name,
                Type_flour = type_flour,
                Calories = calories,
                Price = price
            };
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Doughs.Add(dough);
                db.SaveChanges();
                if (db.Doughs.Where(doug => doug == dough).FirstOrDefault() != null)
                    return true;
                else return false;
            }
        }

        public bool ChangeData(string name, int price)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    Dough dough = db.Doughs.Where(Name => Name.Name == name).FirstOrDefault();
                    dough.Price = price;
                    db.SaveChanges();
                } catch (Exception ex) 
                { 
                    Debug.WriteLine("Запись не найдена");
                    return false;
                }
                //--------------------------------------------------------------------------
                if (db.Doughs.Where(Price => Price.Price == price).FirstOrDefault() != null)
                    return true;
                else return false;

            }
        }
        public bool DeleteData(string name)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    Dough dough = db.Doughs.Where(Name => Name.Name == name).FirstOrDefault();
                    db.Doughs.Remove(dough);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Запись не найдена");
                    return false;
                }
                //--------------------------------------------------------------------------
                if (db.Doughs.Where(Name => Name.Name == name).FirstOrDefault() == null)
                    return true;
                else return false;

            }
        }
    }
}
