using System;
using System.Collections.Generic;

namespace PizzaBoxData
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int LocationId { get; set; }
        public int ToppingId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Topping Topping { get; set; }
    }
}
