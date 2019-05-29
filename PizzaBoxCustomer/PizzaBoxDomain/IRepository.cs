using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxDomain
{
    public interface IRepository
    {
        void DisposeInstance();
        //Works
        List<DomTopping> GetToppingList();
        //Works
        DomTopping GetTopping(int id);
        //Works
        List<DomLocation> GetLocationList();
        
        //Works
        List<DomOrder> GetUserOrderList(DomUser u);

        //Works
        List<DomPizza> GetOrderPizzas(DomOrder o);
        //Works
        List<DomPizzaTopping> GetPizzaToppings(DomPizza p);

        DomOrder GetMostRecentOrder(DomUser u);

        //works
        bool PassValidation(string uname, string pwrd);

        //works
        bool UserNameTaken(string username);

        //works
        void AddOrder(DomOrder o);

        //works
        void RemoveOrder(DomOrder o);
        //works
        void AddUser(DomUser u);
        //works
        void UpdateUser(DomUser u);
        //works
        void RemoveUser(DomUser u);
        //works
        DomUser GetUser(string username);
    }
}
