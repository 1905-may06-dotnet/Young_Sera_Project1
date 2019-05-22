using System;
using System.Collections.Generic;

namespace PizzaBoxData
{
    public partial class Location
    {
        public Location()
        {
            Inventory = new HashSet<Inventory>();
            Order = new HashSet<Order>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
