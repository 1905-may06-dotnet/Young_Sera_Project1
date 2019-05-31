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

        public IActionResult MakePizza()
        {
            //Should add price and number of pizzas validation here.
            return View();
        }

        public IActionResult AddToppings(PizzaModel pizza)
        {
            if (TempData.Peek("PizzaSize") == null)
                TempData.Remove("PizzaSize");
            TempData.Add("PizzaSize", pizza.Size);
            if (TempData.Peek("PizzaCrust") == null)
                TempData.Remove("PizzaCurst");
            TempData.Add("PizzaCrust", pizza.Crust);
            Dictionary<string, int> toppingDict = new Dictionary<string, int>();
            List<DomTopping> toppingList = PRepo.GetToppingList();
            foreach(var t in toppingList)
            {
                toppingDict.Add(t.ToppingName, 0);
            }
            return View(toppingDict);
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
    }
}