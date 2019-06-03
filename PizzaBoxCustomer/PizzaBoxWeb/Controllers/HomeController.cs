using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBoxWeb.Models;
using PizzaBoxDomain;

namespace PizzaBoxWeb.Controllers
{
    public class HomeController : Controller
    {
        IOrderRepository ORepo;
        ILocationRepository LRepo;
        IPizzaRepository PRepo;
        public HomeController(IOrderRepository repo, ILocationRepository lrepo, IPizzaRepository prepo)
        {
            ORepo = repo;
            LRepo = lrepo;
            PRepo = prepo;
        }
        
        public IActionResult Index()
        {
            string username = HttpContext.Session.GetString("Username");
            if(string.IsNullOrEmpty(username))
            {
                return View();
            }
            DomOrder actOrder = ORepo.GetActiveOrder(username);
            if (actOrder == null)
                return View();
            actOrder.Pizzas = PRepo.GetOrderPizzas(actOrder);
            foreach(var p in actOrder.Pizzas)
            {
                p.PizzaToppings = PRepo.GetPizzaToppings(p);
                p.CalculateCost();
            }
            OrderModel order = new OrderModel();
            order.cost = actOrder.Cost;
            switch((OrderStatus)actOrder.OrderStatus)
            {
                case OrderStatus.Sent:
                    order.OrderStatus = "sent";
                    break;

                case OrderStatus.Received:
                    order.OrderStatus = "received";
                    break;

                case OrderStatus.Cooking:
                    order.OrderStatus = "in the oven";
                    break;

                case OrderStatus.Delivering:
                    order.OrderStatus = "on the way";
                    break;
            }
            order.locationAddress = LRepo.GetLocation(actOrder.LocationId).Address;
            foreach(var p in actOrder.Pizzas)
            {
                PizzaModel inPizza = new PizzaModel();
                inPizza.Cost = p.Cost;
                inPizza.Crust = p.Crust;
                inPizza.Size = p.Size;
                foreach (var t in p.PizzaToppings)
                {
                    inPizza.toppings.Add(PRepo.GetTopping(t.ToppingId).ToppingName);
                }
                order.Pizzas.Add(inPizza);
            }
            return View(order);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
