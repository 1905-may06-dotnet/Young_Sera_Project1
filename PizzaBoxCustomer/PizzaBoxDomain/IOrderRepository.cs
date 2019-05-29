﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxDomain
{
    public interface IOrderRepository
    {
        void DisposeInstance();
        List<DomOrder> GetUserOrderList(DomUser u);

        DomOrder GetMostRecentOrder(DomUser u);

        void AddOrder(DomOrder o);

        void RemoveOrder(DomOrder o);
    }
}
