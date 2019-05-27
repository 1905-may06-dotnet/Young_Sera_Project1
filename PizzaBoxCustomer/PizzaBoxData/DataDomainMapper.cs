using System;
using System.Collections.Generic;
using System.Text;
using PizzaBoxDomain;

namespace PizzaBoxData
{
    public static class DataDomainMapper
    {
        public static PizzaTopping DomPizzaTopping2PizzaTopping(DomPizzaTopping inTopping)
        {
            PizzaTopping outTopping = new PizzaTopping()
            {
                ToppingId = inTopping.ToppingId
            };
            return outTopping;
        }

        public static Pizza DomPizza2Pizza (DomPizza inPizza)
        {
            Pizza outPizza = new Pizza()
            {
                Crust = inPizza.Crust,
                Size = inPizza.Size,
                Cost = inPizza.Cost
            };

            foreach(var pt in inPizza.PizzaToppings)
            {
                outPizza.PizzaTopping.Add(DomPizzaTopping2PizzaTopping(pt));
            }

            return outPizza;
        }

        public static Order DomOrder2Order(DomOrder inOrder)
        {
            Order outOrder = new Order()
            {
                Username = inOrder.Username,
                LocationId = inOrder.LocationId,
                OrderDate = inOrder.OrderDate,
                OrderStatus = inOrder.OrderStatus,
                Cost = inOrder.Cost
            };
            
            foreach(var p in inOrder.Pizzas)
            {
                outOrder.Pizza.Add(DomPizza2Pizza(p));
            }

            return outOrder;
        }
    }
}
