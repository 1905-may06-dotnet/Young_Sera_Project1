using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaBoxDomain;

namespace PizzaBoxData
{
    public class PizzaRepository : IPizzaRepository
    {
        private PizzaBoxContext _db;
        public PizzaRepository(PizzaBoxContext db)
        {
            _db = db;
        }
        ~PizzaRepository()
        {
            _db.Dispose();
        }
        public List<DomTopping> GetToppingList()
        {
            List<Topping> inToppings = _db.Topping.ToList();
            List <DomTopping> outToppings = new List<DomTopping>();
            foreach(var t in inToppings)
            {
                outToppings.Add(DataDomainMapper.Topping2DomTopping(t));
            }
            return outToppings;
        }

        public DomTopping GetTopping(int id)
        {
            return DataDomainMapper.Topping2DomTopping(_db.Topping.Where<Topping>(t => t.Id == id).FirstOrDefault());
        }

        public void DisposeInstance()
        {
            
        }

        public List<DomPizza> GetOrderPizzas(DomOrder o)
        {
            List<Pizza> inPizzas = _db.Pizza.Where<Pizza>(p => p.OrderId == o.OrderID).ToList();
            List<DomPizza> outPizzas = new List<DomPizza>();
            foreach(var p in inPizzas)
            {
                outPizzas.Add(DataDomainMapper.Pizza2DomPizz(p));
            }
            return outPizzas;
        }
        public List<DomPizzaTopping> GetPizzaToppings(DomPizza p)
        {
            List<PizzaTopping> inPizzaToppings = _db.PizzaTopping.Where<PizzaTopping>(pt => pt.PizzaId == p.PizzaID).ToList();
            List<DomPizzaTopping> outPizzaToppings = new List<DomPizzaTopping>();
            foreach(var pt in inPizzaToppings)
            {
                outPizzaToppings.Add(DataDomainMapper.PizzaTopping2DomPizzaTopping(pt));
            }
            return outPizzaToppings;
        }

        public int GetToppingID (string topname)
        {
            int id = _db.Topping.Where<Topping>(pt => pt.TopName == topname).First().Id;
            return id;
        }
        
    }
}
