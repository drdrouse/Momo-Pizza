namespace Momo_Pizza.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Name { get; set; } 
        public int Diameter {  get; set; }
        public int Price { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }

        //------------
        public int ID_Dough { get; set; }
        public virtual Dough Dough { get; set; }
        //------------
        public int ID_Sauce { get; set; }
        public virtual Sauce Sauces { get; set; }
        //------------
        public virtual ICollection<Filling> Fillings { get; set; }
        //------------
        public virtual ICollection<Order> Orders { get; set; }  
    }
}
