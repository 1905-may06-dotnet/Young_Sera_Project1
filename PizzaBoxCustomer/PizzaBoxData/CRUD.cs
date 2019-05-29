using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaBoxDomain;

namespace PizzaBoxData
{
    public class CRUD : IRepository
    {
        public List<DomTopping> GetToppingList()
        {
            List<Topping> inToppings = DBSingle.Instance.dbInstance.Topping.ToList();
            List <DomTopping> outToppings = new List<DomTopping>();
            foreach(var t in inToppings)
            {
                outToppings.Add(DataDomainMapper.Topping2DomTopping(t));
            }
            return outToppings;
        }

        public DomTopping GetTopping(int id)
        {
            return DataDomainMapper.Topping2DomTopping(DBSingle.Instance.dbInstance.Topping.Where<Topping>(t => t.Id == id).FirstOrDefault());
        }

        public List<DomLocation> GetLocationList()
        {
            List<Location> inLocations = DBSingle.Instance.dbInstance.Location.ToList();
            List<DomLocation> outLocations = new List<DomLocation>();
            foreach(var l in inLocations)
            {
                outLocations.Add(DataDomainMapper.Location2DomLocation(l));
            }
            return outLocations;
        }

        public void DisposeInstance()
        {
            DBSingle.Instance.ResetInstance();
        }

        public List<DomOrder> GetUserOrderList(DomUser u)
        {

            List<Order> orderList = DBSingle.Instance.dbInstance.Order.Where<Order>(o => o.Username == u.Username).ToList();
            List<DomOrder> outList = new List<DomOrder>();
            foreach(var o in orderList)
            {
                outList.Add(DataDomainMapper.Order2DomOrder(o));
            }
            return outList;
        }

        public List<DomPizza> GetOrderPizzas(DomOrder o)
        {
            List<Pizza> inPizzas = DBSingle.Instance.dbInstance.Pizza.Where<Pizza>(p => p.OrderId == o.OrderID).ToList();
            List<DomPizza> outPizzas = new List<DomPizza>();
            foreach(var p in inPizzas)
            {
                outPizzas.Add(DataDomainMapper.Pizza2DomPizz(p));
            }
            return outPizzas;
        }
        public List<DomPizzaTopping> GetPizzaToppings(DomPizza p)
        {
            List<PizzaTopping> inPizzaToppings = DBSingle.Instance.dbInstance.PizzaTopping.Where<PizzaTopping>(pt => pt.PizzaId == p.PizzaID).ToList();
            List<DomPizzaTopping> outPizzaToppings = new List<DomPizzaTopping>();
            foreach(var pt in inPizzaToppings)
            {
                outPizzaToppings.Add(DataDomainMapper.PizzaTopping2DomPizzaTopping(pt));
            }
            return outPizzaToppings;
        }
        public DomOrder GetMostRecentOrder(DomUser u)
        {
            return DataDomainMapper.Order2DomOrder(DBSingle.Instance.dbInstance.Order.Where<Order>(o => o.Username == u.Username).OrderByDescending(o => o.OrderDate).FirstOrDefault());
        }

        public bool PassValidation(string uname, string pwrd)
        {
            return (DBSingle.Instance.dbInstance.User.Where<User>(u => u.Username == uname).FirstOrDefault().Pwrd == pwrd);
        }

        public bool UserNameTaken(string username)
        {
            var userExists = DBSingle.Instance.dbInstance.User.Where<User>(u => u.Username == username).FirstOrDefault();
            if (userExists != null)
                return true;
            else
                return false;
        }

        public void AddOrder(DomOrder o)
        {
            Order newOrder = DataDomainMapper.DomOrder2Order(o);
            DBSingle.Instance.dbInstance.Order.Add(newOrder);
            DBSingle.Instance.dbInstance.SaveChanges();
        }

        public void RemoveOrder(DomOrder o)
        {
            Order remOrder = DataDomainMapper.DomOrder2Order(o);
            Pizza[] pizzas = DBSingle.Instance.dbInstance.Pizza.Where(p => p.OrderId == remOrder.Id).ToArray();
            DBSingle.Instance.dbInstance.Pizza.RemoveRange(pizzas);
            DBSingle.Instance.dbInstance.Order.Remove(remOrder);
            DBSingle.Instance.dbInstance.SaveChanges();
        }

        public void AddUser(DomUser u)
        {
            DBSingle.Instance.dbInstance.User.Add(DataDomainMapper.DomUser2User(u));
            DBSingle.Instance.dbInstance.SaveChanges();
        }

        public void UpdateUser(DomUser u)
        {
            DBSingle.Instance.dbInstance.User.Update(DataDomainMapper.DomUser2User(u));
            DBSingle.Instance.dbInstance.SaveChanges();
        }

        public void RemoveUser(DomUser u)
        {
            DBSingle.Instance.dbInstance.User.Remove(DataDomainMapper.DomUser2User(u));
            DBSingle.Instance.dbInstance.SaveChanges();
        }

        public DomUser GetUser(string username)
        {
            return DataDomainMapper.User2DomUser(DBSingle.Instance.dbInstance.User.Where(u => u.Username == username).FirstOrDefault());
        }
    }
}
