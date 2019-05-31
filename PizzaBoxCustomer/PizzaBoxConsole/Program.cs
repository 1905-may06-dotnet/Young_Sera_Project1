using System;
using PizzaBoxData;
using PizzaBoxDomain;
using System.Collections.Generic;

namespace PizzaBoxConsole
{
    class Program
    {
        static IPizzaRepository pRepo;
        static IOrderRepository oRepo;
        static IUserRepository uRepo;
        static ILocationRepository lRepo;
        static DomUser currUser;
        static DomOrder currOrder;
        static void Main(string[] args)
        {
            pRepo = new PizzaRepository(new PizzaBoxContext());
            oRepo = new OrderRepository(new PizzaBoxContext());
            uRepo = new UserRepository(new PizzaBoxContext());
            lRepo = new LocationRepository(new PizzaBoxContext());
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
                if (uRepo.UserNameTaken(user))
                {
                    Console.WriteLine("Please provide your password or type \'return\': ");
                    string pswrd = Console.ReadLine();
                    if (pswrd == "return")
                        return;
                    if (uRepo.PassValidation(user, pswrd))
                    {
                        currUser = uRepo.GetUser(user);
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
                if (uRepo.UserNameTaken(uname))
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
                List<DomLocation> locList = lRepo.GetLocationList();
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
            DomUser newUser = new DomUser(uname, locId, pass);
            uRepo.AddUser(newUser);
            currUser = newUser;
            UpdateOrderInfo(currUser.LocationId, currUser.Username);
            Console.WriteLine($"Welcome to Pizza Box, {currUser.Username}!");
            WaitForInput();
        }

        static void OrderOptions()
        {
            if (currOrder == null)
            {
                currOrder = new DomOrder();
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
            if(currOrder.IsAtMaxPizzas())
            {
                Console.WriteLine("You have reached the limit on pizzas at 100 pizzas. Please order and try again in 2 hours.");
                WaitForInput();
                return;
            }

            DomPizza newPizza;
            while (true)
            {
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

                List<DomPizzaTopping> toppings = new List<DomPizzaTopping>();
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Select a topping or type \'none\' if you want no toppings or \'return\' to cancel");
                    List<DomTopping> topList = pRepo.GetToppingList();
                    int i = 0;
                    foreach (var top in topList)
                    {
                        Console.WriteLine($"({i}) {top.ToppingName}");
                        i++;
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
                        DomPizzaTopping ptopping = new DomPizzaTopping(choice);
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
                newPizza = new DomPizza((int)crust, (int)size, toppings);

                currOrder.AddPizza(newPizza);
                if (currOrder.IsAtMaxPizzas())
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
            if (currOrder == null || currOrder.Pizzas.Count == 0)
            {
                Console.WriteLine("No current order to remove pizzas from.");
                WaitForInput();
                return;
            }

            while (true)
            {
                Console.Clear();
                currOrder.CalculateCost();
                Console.WriteLine("Select a pizza to remove, or type \'return\' to go back.");
                Console.WriteLine($"Order\t\t\t\tTotal Cost: ${currOrder.Cost}");
                int i = 0;
                foreach (var p in currOrder.Pizzas)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine($"({i})Pizza\t\t\t\tCost: ${p.Cost}");
                    Console.WriteLine($"Crust: {(PizzaCrust)p.Crust}\t\tSize: {(PizzaSize)p.Size}");
                    Console.WriteLine("Toppings: ");
                    foreach (var pt in p.PizzaToppings)
                    {
                        DomTopping t = pRepo.GetTopping((int)pt.ToppingId);
                        Console.WriteLine(t.ToppingName);
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
                else if (choice >= currOrder.Pizzas.Count || choice < 0)
                {
                    Console.WriteLine("Please select a valid pizza number.");
                    WaitForInput();
                }
                else
                {
                    currOrder.RemovePizza(choice);
                }
            }

        }

        static void ViewOrder()
        {
            if(currOrder == null || currOrder.Pizzas.Count == 0)
            {
                Console.WriteLine("No current order to show.");
                WaitForInput();
                return;
            }
            currOrder.CalculateCost();
            Console.WriteLine($"Order\t\t\t\tTotal Cost: ${currOrder.Cost}");
            foreach(var p in currOrder.Pizzas)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Pizza\t\t\t\tCost: ${p.Cost}");
                Console.WriteLine($"Crust: {(PizzaCrust)p.Crust}\t\tSize: {(PizzaSize)p.Size}");
                Console.WriteLine("Toppings: ");
                foreach(var pt in p.PizzaToppings)
                {
                    DomTopping t = pRepo.GetTopping((int)pt.ToppingId);
                    Console.WriteLine(t.ToppingName);
                }
            }
            WaitForInput();
        }

        static void CancelOrder()
        {
            Console.Clear();
            if(currOrder == null || currOrder.Pizzas.Count == 0)
            {
                Console.WriteLine("You currently don't have an order!");
                WaitForInput();
            }
            currOrder.Pizzas.Clear();
            Console.WriteLine("Your pizzas have been removed from your order.");
            WaitForInput();
        }

        static void CheckOut()
        {
            if(currOrder == null || currOrder.Pizzas.Count == 0)
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

            currOrder.CalculateCost();
            currOrder.OrderDate = DateTime.Now;
            currOrder.OrderStatus = (int)OrderStatus.Sent;
            DomOrder lastOrder = oRepo.GetMostRecentOrder(currUser);
            if (lastOrder != null)
            {
                if (currOrder.Within24Hours(lastOrder.OrderDate) && lastOrder.LocationId != currOrder.LocationId)
                {
                    Console.WriteLine("You can't order from a location within 24 hours of ordering from a different location.");
                    WaitForInput();
                    return;
                }

                if (currOrder.Within2Hours(lastOrder.OrderDate))
                {
                    Console.WriteLine("It's been less than 2 hours since your last order. Please wait to order again.");
                    WaitForInput();
                    return;
                }
            }

            if(currOrder.IsAboveMaximumCost())
            {
                Console.WriteLine("Your order costs too much. Please remove pizzas until it is less than $5,000.");
                WaitForInput();
                return;
            }
            oRepo.AddOrder(currOrder);
            currOrder = null;
            Console.WriteLine("Your order has been sent! Enjoy your pizza!");
            WaitForInput();
        }

        static void OrderHistory()
        {
            oRepo.DisposeInstance();
            Console.Clear();
            if(currUser == null)
            {
                Console.WriteLine("Please sign in to view your order history.");
                WaitForInput();
                return;
            }
            List<DomOrder> userHistory = oRepo.GetUserOrderList(currUser);
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
                    if(o.Pizzas.Count== 0)
                    {
                        o.Pizzas = pRepo.GetOrderPizzas(o);
                    }
                    foreach (var p in o.Pizzas)
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine($"Pizza\t\t\t\tCost: ${p.Cost}");
                        Console.WriteLine($"Crust: {(PizzaCrust)p.Crust}\t\tSize: {(PizzaSize)p.Size}");
                        Console.WriteLine("Toppings: ");
                        if(p.PizzaToppings.Count == 0)
                        {
                            p.PizzaToppings = pRepo.GetPizzaToppings(p);
                        }
                        foreach (var pt in p.PizzaToppings)
                        {
                            DomTopping t = pRepo.GetTopping((int)pt.ToppingId);
                            Console.WriteLine(t.ToppingName);
                        }
                    }
                    Console.WriteLine("------------------------------------------------------------------");
                }
                userHistory = null;
                oRepo.DisposeInstance();
                WaitForInput();
            }
        }

        static void UpdateLocation()
        {
            uRepo.DisposeInstance();
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
                List<DomLocation> locList = lRepo.GetLocationList();
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
            uRepo.UpdateUser(currUser);
            UpdateOrderInfo(currUser.LocationId, currUser.Username);
            uRepo.DisposeInstance();
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
