namespace Momo_Pizza.Models
{
    public class Basket
    {
        public int BasketId { get; set; }
        //------------
        public Guid User_ID { get; set; }
        public virtual User User { get; set; }
        //------------
        public virtual ICollection<Order> Orders { get; set; }
    }
}
