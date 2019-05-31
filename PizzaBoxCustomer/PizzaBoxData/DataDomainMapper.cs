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
           
            if(inOrder.OrderID != null)
            {
                outOrder.Id = (int)inOrder.OrderID;
            }
            
            foreach(var p in inOrder.Pizzas)
            {
                outOrder.Pizza.Add(DomPizza2Pizza(p));
            }
                   
            return outOrder;
        }

        public static DomOrder Order2DomOrder(Order inOrder)
        {
            List<DomPizza> domPizzas = new List<DomPizza>();
            foreach(var p in inOrder.Pizza)
            {
                domPizzas.Add(Pizza2DomPizz(p));
            }
            DomOrder outOrder = new DomOrder(inOrder.Username, inOrder.LocationId, inOrder.OrderDate, inOrder.OrderStatus, domPizzas);
            outOrder.Cost = inOrder.Cost;
            outOrder.OrderID = inOrder.Id;
            return outOrder;
        }

        public static DomPizza Pizza2DomPizz(Pizza inPizza)
        {
            List<DomPizzaTopping> domPTs = new List<DomPizzaTopping>();
            foreach(var pt in inPizza.PizzaTopping)
            {
                domPTs.Add(PizzaTopping2DomPizzaTopping(pt));
            }
            DomPizza outPizza = new DomPizza(inPizza.Crust, inPizza.Size, domPTs);
            return outPizza;
        }

        public static DomPizzaTopping PizzaTopping2DomPizzaTopping(PizzaTopping inPt)
        {
            DomPizzaTopping outPt = new DomPizzaTopping(inPt.ToppingId);
            return outPt;
        }

        public static DomUser User2DomUser(User inUser)
        {
            DomUser outUser = new DomUser(inUser.Username, inUser.LocationId, inUser.Pwrd);
            return outUser;
        }

        public static User DomUser2User(DomUser inUser)
        {
            User outUser = new User()
            {
                Username = inUser.Username,
                LocationId = inUser.LocationId,
                Pwrd = inUser.Password
            };

            return outUser;
        }

        public static DomTopping Topping2DomTopping(Topping inTopping)
        {
            DomTopping outTopping = new DomTopping()
            {
                ToppingName = inTopping.TopName
            };
            return outTopping;
        }

        public static DomLocation Location2DomLocation(Location inLocation)
        {
            DomLocation outLocation = new DomLocation()
            {
                Id = inLocation.Id,
                Address = inLocation.Address
            };
            return outLocation;
        }
    }
}
