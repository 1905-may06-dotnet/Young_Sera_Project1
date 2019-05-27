using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxDomain
{
    public class DomPizzaTopping
    {
        public DomPizza Pizza { get; }

        public int ToppingId { get; }

        public DomPizzaTopping(DomPizza pizza, int toppingId)
        {
            Pizza = pizza;
            ToppingId = toppingId;
        }

        public DomPizzaTopping()
        {        }
    }
}
