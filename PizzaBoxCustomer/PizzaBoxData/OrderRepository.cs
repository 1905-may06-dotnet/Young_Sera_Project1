using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaBoxDomain;

namespace PizzaBoxData
{
    public class OrderRepository : IOrderRepository
    {
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
        public DomOrder GetMostRecentOrder(DomUser u)
        {
            return DataDomainMapper.Order2DomOrder(DBSingle.Instance.dbInstance.Order.Where<Order>(o => o.Username == u.Username).OrderByDescending(o => o.OrderDate).FirstOrDefault());
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
    }
}
