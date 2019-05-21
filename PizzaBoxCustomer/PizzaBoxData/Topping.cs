using System;
using System.Collections.Generic;

namespace PizzaBoxData
{
    public partial class Topping
    {
        public Topping()
        {
            Inventory = new HashSet<Inventory>();
            PizzaTopping = new HashSet<PizzaTopping>();
        }

        public int Id { get; set; }
        public string TopName { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<PizzaTopping> PizzaTopping { get; set; }
    }
}
