using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxDomain
{
    public class DomInventory
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int LocationId { get; set; }
        public int ToppingId { get; set; }
    }
}
