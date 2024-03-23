﻿namespace Momo_Pizza.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        //------------
        public virtual ICollection<Basket> Baskets { get; set;}

    }
}
