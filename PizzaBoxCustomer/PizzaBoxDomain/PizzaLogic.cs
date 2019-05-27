using System;
using PizzaBoxData;

namespace PizzaBoxDomain
{
    public static class PizzaLogic
    {
        public static decimal CalcPizzaCost(Pizza p)
        {
            PizzaSize pizzaSize = (PizzaSize)p.Size;
            PizzaCrust pizzaCrust = (PizzaCrust)p.Crust;

            decimal cost = 0m;

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

            if (p.PizzaTopping.Count > 2)
            {
                cost += (p.PizzaTopping.Count - 2) * .25m;
            }

            return cost;
        }

        public static decimal CalcOrderCost(Order o)
        {
            decimal cost = 0.0m;
            foreach(var p in o.Pizza)
            {
                cost += CalcPizzaCost(p);
            }
            return cost;
        }

        public static bool WithinTimeSpan(DateTime oldDate, DateTime currDate, TimeSpan withinTime)
        {
            return (currDate - oldDate) < withinTime;
        }

        public static bool IsAboveMaximumCost(decimal cost)
        {
            return cost > 5000;
        }

        public static bool IsAboveMaxPizzaCount(int count)
        {
            return count > 100;
        }

        public static void SetOrderTime(Order o)
        {
            o.OrderDate = DateTime.Now;
        }
    }
}
