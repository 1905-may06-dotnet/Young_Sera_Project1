using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxDomain
{
    public interface IPizzaRepository
    {
        void DisposeInstance();
        List<DomTopping> GetToppingList();
        DomTopping GetTopping(int id);
        
        List<DomPizza> GetOrderPizzas(DomOrder o);
        
        List<DomPizzaTopping> GetPizzaToppings(DomPizza p);
    }
}
