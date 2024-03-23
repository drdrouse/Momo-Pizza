namespace Momo_Pizza.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public double? Calories { get; set; }
        public int Price { get; set; }  
        public string Photo { get; set; }
        //------------
        public virtual ICollection<Filling> Fillings { get; set; }
    }
}
