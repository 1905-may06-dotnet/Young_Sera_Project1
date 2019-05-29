using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaBoxDomain;
using PizzaBoxData;

namespace PizzaBoxTest
{
    [TestClass]
    public class MapperTest
    {
        [TestMethod]
        public void TestPizzaToppingMap()
        {
            //Arrange
            DomPizzaTopping testDPT = new DomPizzaTopping(0);

            //Act
            var testPT = DataDomainMapper.DomPizzaTopping2PizzaTopping(testDPT);

            //Assert
            Assert.IsInstanceOfType(testPT, typeof(PizzaTopping));
        }

        [TestMethod]
        public void TestPizzaMap()
        {
            //Arrange
            DomPizza testDPizza1 = new DomPizza(0, 0, new List<DomPizzaTopping>());
            List<DomPizzaTopping> testList = new List<DomPizzaTopping>();
            testList.Add(new DomPizzaTopping(0));
            DomPizza testDPizza2 = new DomPizza(0, 0, testList);

            //Act
            var testPizza1 = DataDomainMapper.DomPizza2Pizza(testDPizza1);
            var testPizza2 = DataDomainMapper.DomPizza2Pizza(testDPizza2);

            //Assert
            Assert.IsInstanceOfType(testPizza1, typeof(Pizza));
            Assert.IsInstanceOfType(testPizza2, typeof(Pizza));
        }

        [TestMethod]
        public void TestOrderMap()
        {
            //Arrange
            DomOrder testDOrder1 = new DomOrder("test", 0, DateTime.Now, 0, new List<DomPizza>());

            List<DomPizza> pizzaList1 = new List<DomPizza>();
            pizzaList1.Add(new DomPizza(0,0,new List<DomPizzaTopping>()));
            DomOrder testDOrder2 = new DomOrder("test", 0, DateTime.Now, 0, pizzaList1);

            List<DomPizza> pizzaList2 = new List<DomPizza>();
            List<DomPizzaTopping> toppingList1 = new List<DomPizzaTopping>();
            toppingList1.Add(new DomPizzaTopping(0));
            pizzaList2.Add(new DomPizza(0, 0, toppingList1));
            DomOrder testDOrder3 = new DomOrder("test", 0, DateTime.Now, 0, pizzaList2);

            //Act
            var testOrder1 = DataDomainMapper.DomOrder2Order(testDOrder1);
            var testOrder2 = DataDomainMapper.DomOrder2Order(testDOrder2);
            var testOrder3 = DataDomainMapper.DomOrder2Order(testDOrder3);

            //Assert
            Assert.IsInstanceOfType(testOrder1, typeof(Order));
            Assert.IsInstanceOfType(testOrder2, typeof(Order));
            Assert.IsInstanceOfType(testOrder3, typeof(Order));

        }
    }
}
