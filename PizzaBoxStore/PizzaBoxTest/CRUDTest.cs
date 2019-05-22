using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PizzaBoxData;

namespace PizzaBoxTest
{
    [TestClass]
    public class CRUDTest
    {
        [TestMethod]
        public void UserExistsTest()
        {
            //Arrange
            CRUD crud = new CRUD();
            bool exists;
            bool doesnot;

            //Act
            exists = crud.UserNameTaken("first");
            doesnot = crud.UserNameTaken("NotHere");

            //Assert
            Assert.AreEqual(true, exists);
            Assert.AreEqual(false, doesnot);
        }

        [TestMethod]
        public void RetrieveUserTest()
        {
            //Arrange
            CRUD crud = new CRUD();
            User u;

            //Act
            u = crud.GetUser("first");

            //Assert
            Assert.IsNotNull(u);
        }

        [TestMethod]
        public void AddUserTest()
        {
            //Arrange
            CRUD crud = new CRUD();
            bool exists;
            User newUser = new User() { Username = "test", LocationId = 0 };

            //Act
            crud.AddUser(newUser);
            exists = crud.UserNameTaken("test");

            //Assert
            Assert.AreEqual(true, exists);


        }

        [TestMethod]
        public void AddOrderTest()
        {
            //Arrange
            CRUD crud = new CRUD();
            bool exists;
            List<Order> userOrders;
            User testUser = crud.GetUser("Test");
            Order newOrder = new Order() { Username = testUser.Username, LocationId = testUser.LocationId };
            Pizza newPizza = new Pizza() { Crust = 0, Size = 1, };
            newOrder.Pizza.Add(newPizza);

            //Act
            crud.AddOrder(newOrder);
            userOrders = crud.GetUserOrderList(testUser);
            exists = userOrders.Count > 0 ? true : false;
            crud.RemoveOrder(newOrder);

            //Assert
            Assert.AreEqual(true, exists);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            //Arrange
            CRUD crud = new CRUD();
            int changeLoc;
            User pulledUser = crud.GetUser("test");
            pulledUser.LocationId = 1;

            //Act
            crud.UpdateUser(pulledUser);
            changeLoc = (int)crud.GetUser("test").LocationId;

            //Assert
            Assert.AreEqual(1, changeLoc);

        }

        [TestMethod]
        public void RemoveUserTest()
        {
            //Arrange
            CRUD crud = new CRUD();
            bool doesnot;
            User newUser = crud.GetUser("test");

            //Act
            crud.RemoveUser(newUser);
            doesnot = crud.UserNameTaken("test");

            //Assert
            Assert.AreEqual(false, doesnot);
        }
    }
}
