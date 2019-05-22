using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaBoxData
{
    public class CRUD
    {
        public List<Topping> GetToppingList()
        {
            return DBSingle.Instance.dbInstance.Topping.ToList();
        }

        public Topping GetTopping(int id)
        {
            return DBSingle.Instance.dbInstance.Topping.Where<Topping>(t => t.Id == id).FirstOrDefault();
        }

        public List<Location> GetLocationList()
        {
            return DBSingle.Instance.dbInstance.Location.ToList();
        }

        public void DisposeInstance()
        {
            DBSingle.Instance.ResetInstance();
        }

        public List<Order> GetUserOrderList(User u)
        {
            return DBSingle.Instance.dbInstance.Order.Where<Order>(o => o.Username == u.Username).ToList();
        }

        public HashSet<Pizza> GetOrderPizzas(Order o)
        {
            return DBSingle.Instance.dbInstance.Pizza.Where<Pizza>(p => p.OrderId == o.Id).ToHashSet();
        }
        public HashSet<PizzaTopping> GetPizzaToppings(Pizza p)
        {
            return DBSingle.Instance.dbInstance.PizzaTopping.Where<PizzaTopping>(pt => pt.PizzaId == p.Id).ToHashSet();
        }
        public Order GetMostRecentOrder(User u)
        {
            return DBSingle.Instance.dbInstance.Order.Where<Order>(o => o.Username == u.Username).OrderByDescending(o => o.OrderDate).FirstOrDefault();
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

        public void AddOrder(Order o)
        {
            DBSingle.Instance.dbInstance.Order.Add(o);
            DBSingle.Instance.dbInstance.SaveChanges();
        }

        public void RemoveOrder(Order o)
        {
            Pizza[] pizzas = DBSingle.Instance.dbInstance.Pizza.Where(p => p.OrderId == o.Id).ToArray();
            DBSingle.Instance.dbInstance.Pizza.RemoveRange(pizzas);
            DBSingle.Instance.dbInstance.Order.Remove(o);
            DBSingle.Instance.dbInstance.SaveChanges();
        }

        public void AddUser(User u)
        {
            DBSingle.Instance.dbInstance.User.Add(u);
            DBSingle.Instance.dbInstance.SaveChanges();
        }

        public void UpdateUser(User u)
        {
            DBSingle.Instance.dbInstance.User.Update(u);
            DBSingle.Instance.dbInstance.SaveChanges();
        }

        public void RemoveUser(User u)
        {
            DBSingle.Instance.dbInstance.User.Remove(u);
            DBSingle.Instance.dbInstance.SaveChanges();
        }

        public User GetUser(string username)
        {
            return DBSingle.Instance.dbInstance.User.Where(u => u.Username == username).FirstOrDefault();
        }
    }
}
