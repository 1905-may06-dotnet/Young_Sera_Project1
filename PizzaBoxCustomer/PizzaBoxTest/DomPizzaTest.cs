using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaBoxDomain;


namespace PizzaBoxTest
{
    [TestClass]
    public class DomPizzaTest
    {

        //Test that we can instantiate our Dom Pizza class properly
        [TestMethod]
        public void CreationTest()
        {
            //Arrange
            List<DomPizzaTopping> toppings = new List<DomPizzaTopping>();

            //Act
            DomPizza testPizza = new DomPizza(0, 0, toppings);

            //Assert
            Assert.IsInstanceOfType(testPizza, typeof(DomPizza));
        }

        //Test that the calculated cost method, called from the constructor, is properly calculating cost
        [TestMethod]
        public void CostTest()
        {
            //Arrange
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
            decimal result1;
            decimal result2;
            decimal result3;
            decimal result4;
            decimal result5;
            decimal result6;


            //Act
            DomPizza p1 = new DomPizza((int)PizzaCrust.Standard, (int)PizzaSize.Medium,  top1);
            DomPizza p2 = new DomPizza((int)PizzaCrust.Handtossed, (int)PizzaSize.Personal, top1);
            DomPizza p3 = new DomPizza((int)PizzaCrust.Cauliflower, (int)PizzaSize.Personal, top1);
            DomPizza p4 = new DomPizza((int)PizzaCrust.Standard, (int)PizzaSize.Large, top1);
            DomPizza p5 = new DomPizza((int)PizzaCrust.Standard, (int)PizzaSize.Medium, top2);
            DomPizza p6 = new DomPizza((int)PizzaCrust.Standard, (int)PizzaSize.Medium, top3);
            
            result1 = p1.Cost;
            result2 = p2.Cost;
            result3 = p3.Cost;
            result4 = p4.Cost;
            result5 = p5.Cost;
            result6 = p6.Cost;

            //Assert
            Assert.AreEqual(10m, result1);
            Assert.AreEqual(6.5m, result2);
            Assert.AreEqual(7m, result3);
            Assert.AreEqual(15m, result4);
            Assert.AreEqual(10.25m, result5);
            Assert.AreEqual(10.75m, result6);
        }
    }
}

