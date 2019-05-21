using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaBoxData;
using PizzaBoxDomain;

namespace PizzaBoxTest
{
    [TestClass]
    public class PizzaLogicTest
    {
        [TestMethod]
        public void PizzaCostTest()
        {
            //Arrange
            ICollection<PizzaTopping> top1 = new HashSet<PizzaTopping>();
            top1.Add(new PizzaTopping());
            top1.Add(new PizzaTopping());
            ICollection<PizzaTopping> top2 = new HashSet<PizzaTopping>();
            top2.Add(new PizzaTopping());
            top2.Add(new PizzaTopping());
            top2.Add(new PizzaTopping());
            ICollection<PizzaTopping> top3 = new HashSet<PizzaTopping>();
            top3.Add(new PizzaTopping());
            top3.Add(new PizzaTopping());
            top3.Add(new PizzaTopping());
            top3.Add(new PizzaTopping());
            top3.Add(new PizzaTopping());
            //string[] top1 = { "peperroni", "olives" };
            //string[] top2 = { "sausage", "jalepenos", "mushrooms" };
            //string[] top3 = { "sausage", "olives", "jalepenos", "mushrooms", "peperroni", "pineapples" };
            Pizza p1 = new Pizza() { Crust = (int)PizzaCrust.Standard, Size = (int)PizzaSize.Medium, PizzaTopping = top1 };
            Pizza p2 = new Pizza() { Crust = (int)PizzaCrust.Handtossed, Size = (int)PizzaSize.Personal, PizzaTopping = top1 };
            Pizza p3 = new Pizza() { Crust = (int)PizzaCrust.Cauliflower, Size = (int)PizzaSize.Personal, PizzaTopping = top1 };
            Pizza p4 = new Pizza() { Crust = (int)PizzaCrust.Standard, Size = (int)PizzaSize.Large, PizzaTopping = top1 };
            Pizza p5 = new Pizza() { Crust = (int)PizzaCrust.Standard, Size = (int)PizzaSize.Medium, PizzaTopping = top2 };
            Pizza p6 = new Pizza() { Crust = (int)PizzaCrust.Standard, Size = (int)PizzaSize.Medium, PizzaTopping = top3 };
            decimal result1;
            decimal result2;
            decimal result3;
            decimal result4;
            decimal result5;
            decimal result6;

            //Act
            result1 = PizzaLogic.CalcPizzaCost(p1);
            result2 = PizzaLogic.CalcPizzaCost(p2);
            result3 = PizzaLogic.CalcPizzaCost(p3);
            result4 = PizzaLogic.CalcPizzaCost(p4);
            result5 = PizzaLogic.CalcPizzaCost(p5);
            result6 = PizzaLogic.CalcPizzaCost(p6);

            //Assert
            Assert.AreEqual(10m, result1);
            Assert.AreEqual(6.5m, result2);
            Assert.AreEqual(7m, result3);
            Assert.AreEqual(15m, result4);
            Assert.AreEqual(10.25m, result5);
            Assert.AreEqual(10.75m, result6);
        }

        [TestMethod]
        public void OrderCostTet()
        {
            //Arrange
            ICollection<PizzaTopping> top1 = new HashSet<PizzaTopping>();
            top1.Add(new PizzaTopping());
            top1.Add(new PizzaTopping());
            Pizza p1 = new Pizza() { Crust = (int)PizzaCrust.Standard, Size = (int)PizzaSize.Medium, PizzaTopping = top1 };
            Pizza p2 = new Pizza() { Crust = (int)PizzaCrust.Handtossed, Size = (int)PizzaSize.Personal, PizzaTopping = top1 };
            Pizza p3 = new Pizza() { Crust = (int)PizzaCrust.Cauliflower, Size = (int)PizzaSize.Personal, PizzaTopping = top1 };

            Order testOrder = new Order();
            testOrder.Pizza.Add(p1);
            testOrder.Pizza.Add(p2);
            testOrder.Pizza.Add(p3);

            //Act
            decimal testVal = PizzaLogic.CalcOrderCost(testOrder);

            //Assert
            Assert.AreEqual(23.5m, testVal);
        }
    }
}
