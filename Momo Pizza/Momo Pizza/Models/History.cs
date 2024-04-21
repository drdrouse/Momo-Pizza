namespace Momo_Pizza.Models
{
    public class History
    {
        public int HistoryId { get; set; }
        //------------
        public Guid User_ID { get; set; }
        public virtual User User { get; set; }
        //------------
        public virtual ICollection<Bought> Boughts { get; set; }
    }
}
