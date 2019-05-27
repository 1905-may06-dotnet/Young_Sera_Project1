using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxDomain
{

    public enum PizzaCrust
    {
        Standard,
        Handtossed,
        Thin,
        Cauliflower
    }

    public enum PizzaSize
    {
        Personal,
        Medium,
        Large
    }
    public class DomPizza
    {
        private decimal cost;
        public decimal Cost { get { return cost; }  }
        public int Size { get; }
        public int Crust { get; }

        public List<DomPizzaTopping> PizzaToppings { get; set; }

        public DomPizza(int crust, int size, List<DomPizzaTopping> toppings)
        {
            Size = size;
            Crust = crust;
            if (toppings.Count < 6)
            {
                PizzaToppings = toppings;
            }
            else
            {
                PizzaToppings = new List<DomPizzaTopping>();
            }
            CalculateCost();
        }

        private void CalculateCost()
        {
            PizzaSize pizzaSize = (PizzaSize)Size;
            PizzaCrust pizzaCrust = (PizzaCrust)Crust;

            cost = 0m;

            switch (pizzaSize)
            {
                case PizzaSize.Large:
                    cost += 15m;
                    break;
                case PizzaSize.Personal:
                    cost += 5m;
                    break;
                default:
                    cost += 10m;
                    break;
            }

            switch (pizzaCrust)
            {
                case PizzaCrust.Thin:
                    cost += 1.25m;
                    break;
                case PizzaCrust.Handtossed:
                    cost += 1.50m;
                    break;
                case PizzaCrust.Cauliflower:
                    cost += 2;
                    break;
            }

            if (PizzaToppings.Count > 2)
            {
                cost += (PizzaToppings.Count - 2) * .25m;
            }
        }
    }
}
