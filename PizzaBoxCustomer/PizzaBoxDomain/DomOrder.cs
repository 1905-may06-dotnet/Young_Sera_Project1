using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxDomain
{
    public enum OrderStatus
    {
        Sent,
        Received,
        Cooking,
        Delivering,
        Complete,
        Canceled
    }
    public class DomOrder
    {
        private decimal cost;
        public int? OrderID { get; set; }
        public string Username { get; set; }
        public int LocationId { get; set; }
        public decimal Cost { get { return cost; } }

        public DateTime OrderDate { get; set;  }
        public int OrderStatus { get; set; }

        public List<DomPizza> Pizzas { get; set; }

        public DomOrder(string username, int locationId, DateTime orderDate, int orderStatus, List<DomPizza> pizzas)
        {
            Username = username;
            LocationId = locationId;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
            if (pizzas.Count < 101)
            {
                Pizzas = pizzas;
            }
            else
            {
                Pizzas = new List<DomPizza>();
            }
            CalculateCost();
        }

        public DomOrder()
        {
            Pizzas = new List<DomPizza>();
        }

        public void CalculateCost()
        {
            cost = 0.0m;
            foreach (var p in Pizzas)
            {
                cost += p.Cost;
            }
        }

        public bool Within2Hours(DateTime oldDate)
        {
            return (OrderDate - oldDate) < TimeSpan.FromHours(2);
        }

        public bool Within24Hours(DateTime oldDate)
        {
            return (OrderDate - oldDate) < TimeSpan.FromDays(1);
        }

        public bool IsAboveMaximumCost()
        {
            return Cost > 5000;
        }

        public bool IsAtMaxPizzas()
        {
            return Pizzas.Count >= 100;
        }

        public bool AddPizza(DomPizza newPizza)
        {
            if(Pizzas.Count < 100)
            {
                Pizzas.Add(newPizza);
                return true;
            }
            return false;
        }

        public void RemovePizza(DomPizza oldPizza)
        {
            Pizzas.Remove(oldPizza);
        }

        public void RemovePizza(int index)
        {
            Pizzas.RemoveAt(index);
        }
    }
}
