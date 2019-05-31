using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBoxWeb.Models
{
    public class PizzaModel
    {
        public decimal Cost { get; set; }

        public int Size { get; set; }

        public int Crust {get; set;}

        public List<string> toppings;

        public PizzaModel()
        {
            toppings = new List<string>();
        }
    }
}
