namespace Momo_Pizza.Models
{
    public class Filling
    {
        public int FillingId { get; set; }
        public int Count { get; set; }
        //------------
        public int Id_Pizza { get; set; }
        public virtual Pizza Pizza { get; set; }
        //------------
        public int IndredientID { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
