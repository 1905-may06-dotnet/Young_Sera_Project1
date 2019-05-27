using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaBoxDomain;



namespace PizzaBoxTest
{
    [TestClass]
    public class DomOrderTest
    {
        [TestMethod]
        public void OrderInitializationTest()
        {
            //arrange
            List<DomPizza> pizzas = new List<DomPizza>();

            // act
            DomOrder domOrder = new DomOrder("test", 1, DateTime.Now, 0, pizzas);

            // Assert
            Assert.IsInstanceOfType(domOrder, typeof(DomOrder));
        }

        [TestMethod]
        public void OrderCostTest()
        {
            //arrange
            List<DomPizzaTopping> top1 = new List<DomPizzaTopping>();
            top1.Add(new DomPizzaTopping());
            top1.Add(new DomPizzaTopping());
            List<DomPizzaTopping> top2 = new List<DomPizzaTopping>();
            top2.Add(new DomPizzaTopping());
            top2.Add(new DomPizzaTopping());
            top2.Add(new DomPizzaTopping());
            List<DomPizzaTopping> top3 = new List<DomPizzaTopping>();
            top3.Add(new DomPizzaTopping());
            top3.Add(new DomPizzaTopping());
            top3.Add(new DomPizzaTopping());
            top3.Add(new DomPizzaTopping());
            top3.Add(new DomPizzaTopping());

            List<DomPizza> pizzas1 = new List<DomPizza>();
            pizzas1.Add(new DomPizza(0, 0, top1));

            List<DomPizza> pizzas2 = new List<DomPizza>();
            pizzas2.Add(new DomPizza(1, 1, top2));
            pizzas2.Add(new DomPizza(2, 2, top3));

            decimal Result1;
            decimal Result2;
            decimal Result3;

            //Act
            //Empty order
            DomOrder order1 = new DomOrder("test", 0, DateTime.Now, 0, new List<DomPizza>());
            Result1 = order1.Cost;
            
            //Order with one pizza
            DomOrder order2 = new DomOrder("test", 0, DateTime.Now, 0, pizzas1);
            Result2 = order2.Cost;

            //Order with two pizzas
            DomOrder order3 = new DomOrder("test", 0, DateTime.Now, 0, pizzas2);
            Result3 = order3.Cost;

            //Assert
            Assert.AreEqual(0.0m, Result1);
            Assert.AreEqual(5.0m, Result2);
            Assert.AreEqual(11.75m + 17.0m, Result3);

        }

        [TestMethod]
        public void Within2HoursTest()
        {
            //Arrange
            DateTime passDate = DateTime.Now - TimeSpan.FromHours(3);
            DateTime failDate = DateTime.Now - TimeSpan.FromHours(.5);
            DomOrder order1 = new DomOrder("test", 0, DateTime.Now, 0, new List<DomPizza>());

            //Act
            bool result1 = order1.Within2Hours(passDate);
            bool result2 = order1.Within2Hours(failDate);

            //Assert
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);

        }

        [TestMethod]
        public void Withing24HoursTest()
        {
            //Arrange
            DateTime passDate = DateTime.Now - TimeSpan.FromDays(1);
            DateTime failDate = DateTime.Now - TimeSpan.FromDays(.5);
            DomOrder order1 = new DomOrder("test", 0, DateTime.Now, 0, new List<DomPizza>());

            //Act
            bool result1 = order1.Within24Hours(passDate);
            bool result2 = order1.Within24Hours(failDate);

            //Assert
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        //It's not possible for an order to exceed 5000 dollars due to the maximum cost of a pizza being too low.
        //Still, the condition exists all the same. We can show it returning false.
        [TestMethod]
        public void TestAboveMaxCost()
        {
            //Arrange
            List<DomPizzaTopping> top = new List<DomPizzaTopping>();
            top.Add(new DomPizzaTopping());
            top.Add(new DomPizzaTopping());
            top.Add(new DomPizzaTopping());
            top.Add(new DomPizzaTopping());
            top.Add(new DomPizzaTopping());
            List<DomPizza> pizzas1 = new List<DomPizza>();
            for (int i = 0; i < 100; i++)
            {
                pizzas1.Add(new DomPizza(3, 2, top));
            }
            DomOrder testOrder = new DomOrder("Test", 0, DateTime.Now, 0, pizzas1);
            bool isTooMuch;

            //Act
            isTooMuch = testOrder.IsAboveMaximumCost();

            //Assert
            Assert.IsFalse(isTooMuch);
        }

        [TestMethod]
        public void AddPizzaTest()
        {
            //Arrange
            DomOrder testOrder = new DomOrder();
            bool pizzaAdded = false;
            bool pizzaNotAdded = true;

            //Act
            for(int i = 0; i < 100; i++)
            {
                pizzaAdded = testOrder.AddPizza(new DomPizza(0,0,new List<DomPizzaTopping>()));
            }
            pizzaNotAdded = testOrder.AddPizza(new DomPizza(0, 0, new List<DomPizzaTopping>()));

            //Assert
            Assert.IsTrue(pizzaAdded);
            Assert.IsFalse(pizzaNotAdded);
        }

        [TestMethod]
        public void RemovePizzaTest()
        {
            //Arrange
            DomOrder testOrder1 = new DomOrder();
            DomPizza pizza1 = new DomPizza(0, 0, new List<DomPizzaTopping>());
            testOrder1.AddPizza(pizza1);
            DomOrder testOrder2 = new DomOrder();
            testOrder2.AddPizza(new DomPizza(0, 0, new List<DomPizzaTopping>()));

            //Act
            testOrder1.RemovePizza(pizza1);
            testOrder2.RemovePizza(0);

            //Assert
            Assert.AreEqual(0, testOrder1.Pizzas.Count);
            Assert.AreEqual(0, testOrder2.Pizzas.Count);
        }
    }
}
