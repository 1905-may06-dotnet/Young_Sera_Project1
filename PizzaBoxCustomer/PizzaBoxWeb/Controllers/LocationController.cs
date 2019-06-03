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
    public class LocationController : Controller
    {
        ILocationRepository LRepo;
        IPizzaRepository PRepo;
        public LocationController(ILocationRepository lrepo, IPizzaRepository prepo)
        {
            LRepo = lrepo;
            PRepo = prepo;
        }
        public IActionResult Location()
        {
            List<DomLocation> list = LRepo.GetLocationList();
            List<LocationModel> mList = new List<LocationModel>();
            foreach (var l in list)
            {
                LocationModel nl = new LocationModel();
                nl.Id = l.Id;
                nl.address = l.Address;
                mList.Add(nl);
            }
            return View(mList);
        }

        public IActionResult LocationOptions(LocationModel model)
        {
            if(model != null)
            {
                HttpContext.Session.SetInt32("LocationAccessId", model.Id);
            }
            return View();
        }

        public IActionResult ViewOrders()
        {
            int? id = HttpContext.Session.GetInt32("LocationAccessId");
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<DomOrder> orders = LRepo.GetActiveOrders((int)id);
            foreach (var o in orders)
            {
                o.Pizzas = PRepo.GetOrderPizzas(o);
                foreach(var p in o.Pizzas)
                {
                    p.PizzaToppings = PRepo.GetPizzaToppings(p);
                }
            }
            List<OrderModel> model = new List<OrderModel>();
            foreach (var o in orders)
            {
                OrderModel m = new OrderModel();
                m.cost = o.Cost;
                m.username = o.Username;
                m.OrderDate = o.OrderDate;
                m.OrderStatus = Enum.GetName(typeof(OrderStatus), o.OrderStatus);
                foreach(var p in o.Pizzas)
                {
                    PizzaModel mp = new PizzaModel();
                    mp.Cost = p.Cost;
                    mp.Crust = p.Crust;
                    mp.Size = p.Size;
                    foreach(var pt in p.PizzaToppings)
                    {
                        mp.toppings.Add(PRepo.GetTopping(pt.ToppingId).ToppingName);
                    }
                    m.Pizzas.Add(mp);
                }
                model.Add(m);
            }
            return View(model);
        }

        public IActionResult Sales()
        {
            int? id = HttpContext.Session.GetInt32("LocationAccessId");
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<DomOrder> orders = LRepo.GetAllOrders((int)id);
            List<OrderModel> model = new List<OrderModel>();
            foreach(var o in orders)
            {
                OrderModel m = new OrderModel();
                m.cost = o.Cost;
                m.username = o.Username;
                m.OrderDate = o.OrderDate;
                model.Add(m);
            }
            return View(model);
        }

        public IActionResult Inventory()
        {
            int? id = HttpContext.Session.GetInt32("LocationAccessId");
            if(id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<DomInventory> Inventory = LRepo.GetInventory((int)id);
            if(Inventory == null)
            {
                return View("WarningView", "Inventory is empty.");
            }
            List<InventoryModel> model = new List<InventoryModel>();
            foreach(var i in Inventory)
            {
                InventoryModel m = new InventoryModel();
                m.Quantity = i.Quantity;
                m.Topping = PRepo.GetTopping(i.ToppingId).ToppingName;
                model.Add(m);
            }
            return View(model);
        }

        public IActionResult Users()
        {
            int? id = HttpContext.Session.GetInt32("LocationAccessId");
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<DomUser> users = LRepo.Getusers((int)id);
            List<UserModel> model = new List<UserModel>();
            foreach(var u in users)
            {
                UserModel m = new UserModel();
                m.Username = u.Username;
                model.Add(m);
            }
            return View(model);
        }
    }
}