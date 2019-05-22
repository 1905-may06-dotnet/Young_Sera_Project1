using System;
using System.Collections.Generic;

namespace PizzaBoxData
{
    public partial class PizzaTopping
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual Topping Topping { get; set; }
    }
}
