using System;
using System.Collections.Generic;

namespace PizzaBoxData
{
    public partial class Order
    {
        public Order()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public int LocationId { get; set; }
        public decimal Cost { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }

        public virtual Location Location { get; set; }
        public virtual User UsernameNavigation { get; set; }
        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
