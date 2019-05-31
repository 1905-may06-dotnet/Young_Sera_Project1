using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaBoxDomain;

namespace PizzaBoxData
{
    public class OrderRepository : IOrderRepository
    {
        private PizzaBoxContext _db;
        public OrderRepository(PizzaBoxContext db)
        {
            _db = db;
        }
        ~OrderRepository()
        {
            _db.Dispose();
        }

        public void DisposeInstance()
        {
        }

        public List<DomOrder> GetUserOrderList(DomUser u)
        {

            List<Order> orderList = _db.Order.Where<Order>(o => o.Username == u.Username).ToList();
            List<DomOrder> outList = new List<DomOrder>();
            foreach(var o in orderList)
            {
                outList.Add(DataDomainMapper.Order2DomOrder(o));
            }
            return outList;
        }
        public DomOrder GetMostRecentOrder(DomUser u)
        {
            return DataDomainMapper.Order2DomOrder(_db.Order.Where<Order>(o => o.Username == u.Username).OrderByDescending(o => o.OrderDate).FirstOrDefault());
        }

        public void AddOrder(DomOrder o)
        {
            Order newOrder = DataDomainMapper.DomOrder2Order(o);
            _db.Order.Add(newOrder);
            _db.SaveChanges();
        }

        public void RemoveOrder(DomOrder o)
        {
            Order remOrder = DataDomainMapper.DomOrder2Order(o);
            Pizza[] pizzas = _db.Pizza.Where(p => p.OrderId == remOrder.Id).ToArray();
            _db.Pizza.RemoveRange(pizzas);
            _db.Order.Remove(remOrder);
            _db.SaveChanges();
        }
    }
}
