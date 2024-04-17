namespace Momo_Pizza.Models
{
    public class Dough
    {
        public int DoughId { get; set; }
        public string Name { get; set; }
        public string Type_flour { get; set; }
        public double? Calories { get; set; }
        public int Price { get; set; }
        //------------
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
