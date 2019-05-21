using System;
using System.Collections.Generic;

namespace PizzaBoxData
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaTopping = new HashSet<PizzaTopping>();
        }

        public int Id { get; set; }
        public decimal Cost { get; set; }
        public int OrderId { get; set; }
        public int Crust { get; set; }
        public int Size { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<PizzaTopping> PizzaTopping { get; set; }
    }
}
