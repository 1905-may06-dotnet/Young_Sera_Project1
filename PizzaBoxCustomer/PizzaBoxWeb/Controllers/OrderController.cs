using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBoxDomain;
using PizzaBoxWeb.Models;

namespace PizzaBoxWeb.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository ORepo;
        private IUserRepository URepo;
        private IPizzaRepository PRepo;
        private ILocationRepository LRepo;
        public OrderController(IOrderRepository ORepo, IUserRepository URepo, IPizzaRepository PRepo, ILocationRepository LRepo)
        {
            this.ORepo = ORepo;
            this.URepo = URepo;
            this.PRepo = PRepo;
            this.LRepo = LRepo;
        }
        public IActionResult Order()
        {
            OrderModel myOrder = TempData.peek("Order");
            if(myOrder == null)
            {
                myOrder = new OrderModel();
                TempData.put("Order", myOrder);

            }
            return View(myOrder);
        }

        public IActionResult ClearOrder()
        {
            TempData.Remove("Order");
            return RedirectToAction("Order");
        }

        public IActionResult MakePizza()
        {
            //Should add price and number of pizzas validation here.
            OrderModel order = TempData.peek("Order");
            DomOrder dOrder = new DomOrder();
            dOrder.Cost = order.cost;
            if(dOrder.IsAtMaxPizzas())
            {
                return View("WarningMessage", "You've reached the pizza limit. Please remove a pizza to add a different one.");
            }
            return View();
        }

        public IActionResult AddToppings(PizzaModel pizza)
        {
            if (TempData.Peek("PizzaSize") != null)
                TempData.Remove("PizzaSize");
            TempData.Add("PizzaSize", pizza.Size);
            if (TempData.Peek("PizzaCrust") != null)
                TempData.Remove("PizzaCrust");
            TempData.Add("PizzaCrust", pizza.Crust);
            Dictionary<string, int> toppingDict = new Dictionary<string, int>();
            List<DomTopping> toppingList = PRepo.GetToppingList();
            foreach(var t in toppingList)
            {
                toppingDict.Add(t.ToppingName, 0);
            }
            return View(toppingDict);
        }

        public IActionResult AddToOrder(Dictionary<string,int> toppings)
        {
            int crust = (int)TempData["PizzaCrust"];
            int size = (int)TempData["PizzaSize"];
            List<DomPizzaTopping> inToppings = new List<DomPizzaTopping>();
            foreach(KeyValuePair<string,int> top in toppings)
            {
                for(int i = 0; i < top.Value; i++)
                {
                    int id = PRepo.GetToppingID(top.Key);
                    DomPizzaTopping pt = new DomPizzaTopping(id);
                    inToppings.Add(pt);
                }
            }

            DomPizza pizza = new DomPizza(crust, size, inToppings);
            PizzaModel inPizza = new PizzaModel();
            inPizza.Cost = pizza.Cost;
            inPizza.Crust = pizza.Crust;
            inPizza.Size = pizza.Size;
            foreach(var t in pizza.PizzaToppings)
            {
                inPizza.toppings.Add(PRepo.GetTopping(t.ToppingId).ToppingName);
            }
            OrderModel order = TempData.get("Order");
            if (order == null)
                return View("WarningMessage", "Session timed out.");
            order.cost += inPizza.Cost;
            order.Pizzas.Add(inPizza);
            TempData.put("Order", order);
            return RedirectToAction("Order");

        }

        public IActionResult ShowOrderHistory()
        {
            if(string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return View("WarningMessage", "Must be logged in to view your user history.");
            }
            DomUser user = URepo.GetUser(HttpContext.Session.GetString("Username"));
            List<DomOrder> list = ORepo.GetUserOrderList(user);
            foreach(var o in list)
            {
                if(o.Pizzas.Count == 0)
                {
                    o.Pizzas = PRepo.GetOrderPizzas(o);
                }
                foreach(var p in o.Pizzas)
                {
                    if(p.PizzaToppings.Count == 0)
                    {
                        p.PizzaToppings = PRepo.GetPizzaToppings(p);
                    }
                }
            }

            List<OrderModel> olist = new List<OrderModel>();
            foreach(var o in list)
            {
                OrderModel m = new OrderModel();
                m.username = o.Username;
                m.OrderDate = o.OrderDate;
                OrderStatus os = (OrderStatus)o.OrderStatus;
                m.OrderStatus = Enum.GetName(typeof(OrderStatus), os);
                m.locationAddress = LRepo.GetLocation(o.LocationId).Address;
                m.cost = o.Cost;
                foreach(var p in o.Pizzas)
                {
                    PizzaModel np = new PizzaModel();
                    np.Cost = p.Cost;
                    np.Crust = p.Crust;
                    np.Size = p.Size;
                    foreach(var pt in p.PizzaToppings)
                    {
                        np.toppings.Add(PRepo.GetTopping(pt.ToppingId).ToppingName);
                    }
                    m.Pizzas.Add(np);
                }
                olist.Add(m);
            }

            return View(olist);
        }

        public IActionResult Checkout()
        {
            string username = HttpContext.Session.GetString("Username");
            int locId = (int)HttpContext.Session.GetInt32("LocationId");
            if(string.IsNullOrEmpty(username))
            {
                return View("WarningMessage", "You must be logged in to place an order.");
            }
            
            OrderModel order = TempData.get("Order");

            if(order.Pizzas.Count == 0)
            {
                return View("WarningMessage", "Can't place an order with no pizzas. Please add pizzas to your order.");
            }
            List<DomPizza> pList = new List<DomPizza>();
            foreach(var p in order.Pizzas)
            {
                List<DomPizzaTopping> ptList = new List<DomPizzaTopping>();
                foreach (var t in p.toppings)
                {
                    int id = PRepo.GetToppingID(t);
                    DomPizzaTopping pt = new DomPizzaTopping(id);
                    ptList.Add(pt);
                }
                DomPizza pizza = new DomPizza(p.Crust,p.Size,ptList);
                pList.Add(pizza);
            }
            DomOrder DOrder = new DomOrder(username,locId,DateTime.Now,0,pList);
            DomOrder lastOrder = ORepo.GetMostRecentOrder(URepo.GetUser(username));
            DateTime lastDate = (lastOrder != null) ? lastOrder.OrderDate : DateTime.MinValue;
            if (DOrder.Within24Hours(lastDate) && DOrder.LocationId != lastOrder.LocationId)
            {
                return View("WarningMessage", "You ordered at a different location within the past 24 hours. Please order there again or wait to order from us.");
            }
            if (DOrder.Within2Hours(lastDate))
            {
                return View("WarningMessage", "You ordered within the last two hours.");
            }
            ORepo.AddOrder(DOrder);
            TempData.Remove("Order");
            return RedirectToAction("Index","Home");
        }
    }
}