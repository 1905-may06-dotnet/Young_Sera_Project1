using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxDomain
{
    public interface ILocationRepository
    {
        void DisposeInstance();
        List<DomLocation> GetLocationList();

        DomLocation GetLocation(int id);

        List<DomUser> Getusers(int LocationId);

        List<DomInventory> GetInventory(int LocationId);

        List<DomOrder> GetActiveOrders(int LocationId);

        List<DomOrder> GetAllOrders(int LocationId);



    }
}
