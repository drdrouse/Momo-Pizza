namespace Momo_Pizza.Models
{
    public class Sauce
    {
        public int SauceId { get; set; }
        public string Name_Sauce { get; set; }
        public string Type_Sauce { get; set; }
        public string Description { get; set; }
        public double? Calories { get; set; }
        public string Photo { get; set; }
        public int Price { get; set; }
        //------------
        public virtual ICollection<Pizza> Pizzas { get; set; }

    }
}
