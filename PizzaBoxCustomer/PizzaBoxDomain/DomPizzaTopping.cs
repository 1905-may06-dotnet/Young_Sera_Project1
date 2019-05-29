using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxDomain
{
    public class DomPizzaTopping
    {

        public int ToppingId { get; }

        public DomPizzaTopping(int toppingId)
        {
            ToppingId = toppingId;
        }

        public DomPizzaTopping()
        {        }
    }
}
