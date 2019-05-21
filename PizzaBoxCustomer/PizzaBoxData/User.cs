using System;
using System.Collections.Generic;

namespace PizzaBoxData
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        public string Username { get; set; }
        public int LocationId { get; set; }
        public string Pwrd { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
