namespace Momo_Pizza.Models
{
    public class Authorized
    {
        public int AuthorizedId { get; set; }
        public string Login {  get; set; }
        public string Password {  get; set; }

        public Guid User_id { get; set; }

    }
}
