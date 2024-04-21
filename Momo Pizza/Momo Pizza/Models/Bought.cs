namespace Momo_Pizza.Models
{
    public class Bought
    {
        public int BoughtId { get; set; }
        //------------
        public int Id_History { get; set; }
        public virtual History History { get; set; }
        //------------
        public int Id_Pizza { get; set; }
        public virtual Pizza Pizza { get; set; }
        //------------
        public int Count { get; set; }
    }
}
