using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaBoxDomain;

namespace PizzaBoxData
{
    public class LocationRepository : ILocationRepository
    {
        private PizzaBoxContext _db;
        public LocationRepository(PizzaBoxContext db)
        {
            _db = db;
        }
        ~LocationRepository()
        {
            _db.Dispose();
        }
        public List<DomLocation> GetLocationList()
        {
            List<Location> inLocations = _db.Location.ToList();
            List<DomLocation> outLocations = new List<DomLocation>();
            foreach(var l in inLocations)
            {
                outLocations.Add(DataDomainMapper.Location2DomLocation(l));
            }
            return outLocations;
        }

        public DomLocation GetLocation(int id)
        {
            return DataDomainMapper.Location2DomLocation(_db.Location.Where(l => l.Id == id).First());
        }

        public List<DomUser> Getusers(int LocationId)
        {
            List<User> users = _db.User.Where<User>(u => u.LocationId == LocationId).ToList();
            if(users == null)
            {
                return null;
            }
            List<DomUser> outUsers = new List<DomUser>();
            foreach(var u in users)
            {
                outUsers.Add(DataDomainMapper.User2DomUser(u));
            }
            return outUsers;
        }

        public List<DomInventory> GetInventory(int LocationId)
        {
            List<Inventory> inventory = _db.Inventory.Where<Inventory>(i => i.LocationId == LocationId).ToList();
            if(inventory == null)
            {
                return null;
            }
            List<DomInventory> outInventory = new List<DomInventory>();
            foreach(var i in inventory)
            {
                outInventory.Add(DataDomainMapper.Inventory2DomInventory(i));
            }
            return outInventory;
        }

        public List<DomOrder> GetActiveOrders(int LocationId)
        {
            List<Order> orders = _db.Order.Where<Order>(o => o.LocationId == LocationId && o.OrderStatus < 4).ToList();
            if(orders == null)
            {
                return null;
            }
            List<DomOrder> outOrders = new List<DomOrder>();
            foreach (var o in orders)
            {
                outOrders.Add(DataDomainMapper.Order2DomOrder(o));
            }
            return outOrders;
        }

        public List<DomOrder> GetAllOrders(int LocationId)
        {
            List<Order> orders = _db.Order.Where<Order>(o => o.LocationId == LocationId && o.OrderStatus != 5).ToList();
            if(orders == null)
            {
                return null;
            }
            List<DomOrder> outOrders = new List<DomOrder>();
            foreach(var o in orders)
            {
                outOrders.Add(DataDomainMapper.Order2DomOrder(o));
            }
            return outOrders;
        }
        public void DisposeInstance()
        {
            
        }
    }
}
