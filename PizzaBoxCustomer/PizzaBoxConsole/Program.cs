using System;
using PizzaBoxData;
using PizzaBoxDomain;
using System.Collections.Generic;

namespace PizzaBoxConsole
{
    class Program
    {
        static CRUD crud;
        static User currUser;
        static Order currOrder;
        static void Main(string[] args)
        {
            crud = new CRUD();
            MainOptions();
        }

        static void MainOptions()
        {
            char choice;
            do
            {
                Console.WriteLine("Welcome to PizzaBox!");
                Console.WriteLine("Please make a selection with your keyboard:");
                Console.WriteLine("(S)ign In | (L)og Out | (C)reate Account | (O)rder Pizza | (P)urchase Order | (V)iew Order History | C(h)ange Location | (E)xit");
                string inp = Console.ReadLine();
                if(inp == "")
                {
                    inp = "s";
                }
                choice = inp[0];
                choice = char.ToLower(choice);
                switch (choice)
                {
                    case 's':
                        SignIn();
                        break;

                    case 'l':
                        SignOut();
                        break;

                    case 'c':
                        CreateAccount();
                        break;

                    case 'o':
                        OrderOptions();
                        break;

                    case 'p':
                        CheckOut();
                        break;

                    case 'v':
                        OrderHistory();
                        break;

                    case 'h':
                        UpdateLocation();
                        break;

                }
                Console.Clear();
            } while (choice != 'e');
        }

        static void SignIn()
        {
            while (true)
            {
                Console.Clear();
                if(currUser != null)
                {
                    Console.WriteLine("You are already signed in. Please sign out if you would like to change accounts.");
                    WaitForInput();
                    return;
                }
                Console.WriteLine("Please provide a username or type \'return\': ");
                string user = Console.ReadLine();
                if (user == "return")
                    return;
                if (crud.UserNameTaken(user))
                {
                    Console.WriteLine("Please provide your password or type \'return\': ");
                    string pswrd = Console.ReadLine();
                    if (pswrd == "return")
                        return;
                    if (crud.PassValidation(user, pswrd))
                    {
                        currUser = crud.GetUser(user);
                        UpdateOrderInfo(currUser.LocationId, currUser.Username);
                        Console.WriteLine($"Welcome back, {currUser.Username}!");
                        WaitForInput();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect username or password.");
                        WaitForInput();
                    }
                }
                else
                {
                    Console.WriteLine("User does not exist. Please try a different user or create an account.");
                    WaitForInput();
                }
            }
        }

        static void SignOut()
        {
            Console.Clear();
            if(currUser == null)
            {
                Console.WriteLine("You are not signed into an account.");
                WaitForInput();
            }
            else
            {
                Console.WriteLine($"Good bye, {currUser.Username}! We hope you come back soon.");
                WaitForInput();
                currUser = null;
            }
        }

        static void CreateAccount()
        {
            Console.Clear();
            if (currUser != null)
            {
                Console.WriteLine("You are already signed in. Please sign out if you would like to create a new account.");
                WaitForInput();
                return;
            }
            string uname;
            string pass;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please enter a username or type \'return\' to cancel.");
                uname = Console.ReadLine();
                if(uname == "return")
                {
                    return;
                }
                if (crud.UserNameTaken(uname))
                {
                    Console.WriteLine("Username already taken. Please try again.");
                    WaitForInput();
                }
                else
                {
                    Console.WriteLine("Please enter a password or type \'return\' to cancel.");
                    pass = Console.ReadLine();
                    if (pass == "return")
                    {
                        return;
                    }
                    break;
                }
            }
            int locId;
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Please select a store location by entering the corresponding number or enter \'return\' to cancel.");
                List<Location> locList = crud.GetLocationList();
                foreach (var loc in locList)
                {
                    Console.WriteLine($"({loc.Id}) {loc.Address}");
                }
                string input = Console.ReadLine();
                locId = Convert.ToInt32(input);
                if(locId >= locList.Count || locId < 0)
                {
                    Console.WriteLine("Please select a valid store number.");
                    WaitForInput();
                }
                else
                {
                    break;
                }
            }
            User newUser = new User() { Username = uname, Pwrd = pass, LocationId = locId };
            crud.AddUser(newUser);
            currUser = newUser;
            UpdateOrderInfo(currUser.LocationId, currUser.Username);
            Console.WriteLine($"Welcome to Pizza Box, {currUser.Username}!");
            WaitForInput();
        }

        static void OrderOptions()
        {
            if (currOrder == null)
            {
                currOrder = new Order();
                if(currUser != null) UpdateOrderInfo(currUser.LocationId, currUser.Username);
            }
            
            char choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Select what you'd like to do with your order: ");
                Console.WriteLine("(A)dd a Pizza | (R)emove a Pizza | (V)iew Your Order | (C)ancel Your Order | R(E)turn to Main Options");
                string inp = Console.ReadLine();
                if(inp == "")
                {
                    inp = "a";
                }
                choice = inp[0];
                choice = char.ToLower(choice);
                switch(choice)
                {
                    case 'a':
                        AddPizza();
                        break;

                    case 'r':
                        RemovePizza();
                        break;

                    case 'v':
                        ViewOrder();
                        break;

                    case 'c':
                        CancelOrder();
                        break;
                }
            } while (choice != 'e');
        }

        static void AddPizza()
        {
            if(PizzaLogic.IsAboveMaxPizzaCount(currOrder.Pizza.Count))
            {
                Console.WriteLine("You have reached the limit on pizzas at 100 pizzas. Please order and try again in 2 hours.");
                WaitForInput();
                return;
            }

            Pizza newPizza;
            while (true)
            {
                newPizza = new Pizza();
                PizzaCrust crust;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Select a Crust or type \'return\' to return to the order menu: ");
                    foreach (var c in Enum.GetValues(typeof(PizzaCrust)))
                    {
                        Console.WriteLine($"({Convert.ToInt32(c)}) {c}");
                    }
                    string input = Console.ReadLine();
                    if (input == "return")
                        return;
                    int choice;
                    if (!int.TryParse(input, out choice))
                    {
                        Console.WriteLine("Please input a number.");
                        WaitForInput();
                    }
                    else if (Enum.IsDefined(typeof(PizzaCrust), choice))
                    {
                        crust = (PizzaCrust)choice;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid Crust.");
                        WaitForInput();
                    }
                }
                newPizza.Crust = (int)crust;

                PizzaSize size;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Select a Size or type \'return\' to return to the order menu: ");
                    foreach (var c in Enum.GetValues(typeof(PizzaSize)))
                    {
                        Console.WriteLine($"({Convert.ToInt32(c)}) {c}");
                    }
                    string input = Console.ReadLine();
                    if (input == "return")
                        return;
                    int choice;
                    if (!int.TryParse(input, out choice))
                    {
                        Console.WriteLine("Please input a number.");
                        WaitForInput();
                    }
                    else if (Enum.IsDefined(typeof(PizzaSize), choice))
                    {
                        size = (PizzaSize)choice;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid Size.");
                        WaitForInput();
                    }
                }
                newPizza.Size = (int)size;

                List<PizzaTopping> toppings = new List<PizzaTopping>();
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Select a topping or type \'none\' if you want no toppings or \'return\' to cancel");
                    List<Topping> topList = crud.GetToppingList();
                    foreach (var top in topList)
                    {
                        Console.WriteLine($"({top.Id}) {top.TopName}");
                    }
                    string input = Console.ReadLine();
                    if (input == "return")
                        return;
                    if (input == "none")
                        break;
                    int choice;
                    if (!int.TryParse(input, out choice))
                    {
                        Console.WriteLine("Please input a number.");
                        WaitForInput();
                    }
                    else if (choice >= topList.Count || choice < 0)
                    {
                        Console.WriteLine("Please select a valid topping.");
                        WaitForInput();
                    }
                    else
                    {
                        PizzaTopping ptopping = new PizzaTopping()
                        {
                            Pizza = newPizza,
                            ToppingId = choice
                        };
                        toppings.Add(ptopping);
                        if (toppings.Count < 5)
                        {
                            Console.Clear();
                            Console.WriteLine("Would you like to add more toppings? (y/n)");
                            input = Console.ReadLine();
                            if (input != "")
                            {
                                char inp = Char.ToLower(input[0]);
                                if (inp == 'n')
                                {
                                    break;
                                }
                            }
                        }
                        else
                            break;
                    }
                }
                newPizza.PizzaTopping = toppings;
                newPizza.Cost = PizzaLogic.CalcPizzaCost(newPizza);

                currOrder.Pizza.Add(newPizza);
                if (currOrder.Pizza.Count < 100)
                {
                    Console.Clear();
                    Console.WriteLine("Would you like to add another pizza? (y/n)");
                    string input = Console.ReadLine();
                    if (input != "")
                    {
                        char inp = Char.ToLower(input[0]);
                        if (inp == 'n')
                        {
                            break;
                        }
                    }
                }
                else
                    break;
            }
        }

        static void RemovePizza()
        {
            if (currOrder == null || currOrder.Pizza.Count == 0)
            {
                Console.WriteLine("No current order to remove pizzas from.");
                WaitForInput();
                return;
            }

            while (true)
            {
                Console.Clear();
                currOrder.Cost = PizzaLogic.CalcOrderCost(currOrder);
                Console.WriteLine("Select a pizza to remove, or type \'return\' to go back.");
                Console.WriteLine($"Order\t\t\t\tTotal Cost: ${currOrder.Cost}");
                int i = 0;
                List<Pizza> list = new List<Pizza>();
                foreach (var p in currOrder.Pizza)
                {
                    list.Add(p);
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine($"({i})Pizza\t\t\t\tCost: ${p.Cost}");
                    Console.WriteLine($"Crust: {(PizzaCrust)p.Crust}\t\tSize: {(PizzaSize)p.Size}");
                    Console.WriteLine("Toppings: ");
                    foreach (var pt in p.PizzaTopping)
                    {
                        Topping t = crud.GetTopping((int)pt.ToppingId);
                        Console.WriteLine(t.TopName);
                    }
                    ++i;
                }
                string input = Console.ReadLine();
                if (input == "return")
                    return;
                int choice;
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Please input a number.");
                    WaitForInput();
                }
                else if (choice >= list.Count || choice < 0)
                {
                    Console.WriteLine("Please select a valid pizza number.");
                    WaitForInput();
                }
                else
                {
                    currOrder.Pizza.Remove(list[choice]);
                }
            }

        }

        static void ViewOrder()
        {
            if(currOrder == null || currOrder.Pizza.Count == 0)
            {
                Console.WriteLine("No current order to show.");
                WaitForInput();
                return;
            }
            currOrder.Cost = PizzaLogic.CalcOrderCost(currOrder);
            Console.WriteLine($"Order\t\t\t\tTotal Cost: ${currOrder.Cost}");
            foreach(var p in currOrder.Pizza)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Pizza\t\t\t\tCost: ${p.Cost}");
                Console.WriteLine($"Crust: {(PizzaCrust)p.Crust}\t\tSize: {(PizzaSize)p.Size}");
                Console.WriteLine("Toppings: ");
                foreach(var pt in p.PizzaTopping)
                {
                    Topping t = crud.GetTopping((int)pt.ToppingId);
                    Console.WriteLine(t.TopName);
                }
            }
            WaitForInput();
        }

        static void CancelOrder()
        {
            Console.Clear();
            if(currOrder == null || currOrder.Pizza.Count == 0)
            {
                Console.WriteLine("You currently don't have an order!");
                WaitForInput();
            }
            currOrder.Pizza.Clear();
            Console.WriteLine("Your pizzas have been removed from your order.");
            WaitForInput();
        }

        static void CheckOut()
        {
            if(currOrder == null || currOrder.Pizza.Count == 0)
            {
                Console.WriteLine("Add pizzas to your order before you checkout!");
                WaitForInput();
                return;
            }

            if(currUser == null)
            {
                Console.WriteLine("Can't check out unless you're signed in.");
                WaitForInput();
                return;
            }

            currOrder.Cost = PizzaLogic.CalcOrderCost(currOrder);
            PizzaLogic.SetOrderTime(currOrder);
            currOrder.OrderStatus = (int)OrderStatus.Sent;
            Order lastOrder = crud.GetMostRecentOrder(currUser);
            if (lastOrder != null)
            {
                if (PizzaLogic.WithinTimeSpan(lastOrder.OrderDate, currOrder.OrderDate, TimeSpan.FromDays(1)) && lastOrder.LocationId != currOrder.LocationId)
                {
                    Console.WriteLine("You can't order from a location within 24 hours of ordering from a different location.");
                    WaitForInput();
                    return;
                }

                if (PizzaLogic.WithinTimeSpan(lastOrder.OrderDate, currOrder.OrderDate, TimeSpan.FromHours(2)))
                {
                    Console.WriteLine("It's been less than 2 hours since your last order. Please wait to order again.");
                    WaitForInput();
                    return;
                }
            }

            if(PizzaLogic.IsAboveMaximumCost(currOrder.Cost))
            {
                Console.WriteLine("Your order costs too much. Please remove pizzas until it is less than $5,000.");
                WaitForInput();
                return;
            }

            crud.AddOrder(currOrder);
            currOrder = null;
            Console.WriteLine("Your order has been sent! Enjoy your pizza!");
            WaitForInput();
        }

        static void OrderHistory()
        {
            crud.DisposeInstance();
            Console.Clear();
            if(currUser == null)
            {
                Console.WriteLine("Please sign in to view your order history.");
                WaitForInput();
                return;
            }
            List<Order> userHistory = crud.GetUserOrderList(currUser);
            if(userHistory.Count == 0)
            {
                Console.WriteLine("You have not made any orders yet.");
                WaitForInput();
                return;
            }
            else
            {
                foreach(var o in userHistory)
                {
                    Console.WriteLine($"Order\t\t\t\tTotal Cost: ${o.Cost}");
                    Console.WriteLine($"Order Status: {(OrderStatus)o.OrderStatus}\tOrder Time: {o.OrderDate}");
                    if(o.Pizza.Count== 0)
                    {
                        o.Pizza = crud.GetOrderPizzas(o);
                    }
                    foreach (var p in o.Pizza)
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine($"Pizza\t\t\t\tCost: ${p.Cost}");
                        Console.WriteLine($"Crust: {(PizzaCrust)p.Crust}\t\tSize: {(PizzaSize)p.Size}");
                        Console.WriteLine("Toppings: ");
                        if(p.PizzaTopping.Count == 0)
                        {
                            p.PizzaTopping = crud.GetPizzaToppings(p);
                        }
                        foreach (var pt in p.PizzaTopping)
                        {
                            Topping t = crud.GetTopping((int)pt.ToppingId);
                            Console.WriteLine(t.TopName);
                        }
                    }
                    Console.WriteLine("------------------------------------------------------------------");
                }
                userHistory = null;
                crud.DisposeInstance();
                WaitForInput();
            }
        }

        static void UpdateLocation()
        {
            if(currUser == null)
            {
                Console.Clear();
                Console.WriteLine("Please log in to set your location.");
                WaitForInput();
                return;
            }
            int locId;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please select a store location by entering the corresponding number or enter \'return\' to cancel.");
                List<Location> locList = crud.GetLocationList();
                foreach (var loc in locList)
                {
                    Console.WriteLine($"({loc.Id}) {loc.Address}");
                }
                string input = Console.ReadLine();
                if(!int.TryParse(input, out locId))
                {
                    Console.WriteLine("Please input a number.");
                    WaitForInput();
                }
                else if (locId >= locList.Count || locId < 0)
                {
                    Console.WriteLine("Please select a valid store number.");
                    WaitForInput();
                }
                else
                {
                    break;
                }
            }
            currUser.LocationId = locId;
            crud.UpdateUser(currUser);
            UpdateOrderInfo(currUser.LocationId, currUser.Username);
        }

        static void WaitForInput()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        static void UpdateOrderInfo(int locId, string username = null)
        {
            if(currOrder != null)
            {
                currOrder.LocationId = locId;
                if (username != null) currOrder.Username = username;
            }
        }
    }
}
