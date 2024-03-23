namespace Momo_Pizza.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        //------------
        public int Id_Basket { get; set; }
        public virtual Basket Basket { get; set; }
        //------------
        public int PizzaId { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
