using System;
using PizzaBoxData;
using PizzaBoxDomain;
using System.Collections.Generic;

namespace PizzaBoxConsole
{
    class Program
    {
        static CRUD crud;
        static Location currLocation;
        static void Main(string[] args)
        {
            crud = new CRUD();
            currLocation = crud.GetLocationList()[0];
            MainOptions();
        }

        static void MainOptions()
        {
            char choice;
            do
            {
                Console.WriteLine("Please make a selection with your keyboard:");
                Console.WriteLine("(O)rders | (S)ales | (I)nventory | (U)sers | (E)xit");
                string inp = Console.ReadLine();
                if (inp == "")
                {
                    inp = "o";
                }
                choice = inp[0];
                choice = char.ToLower(choice);
                switch (choice)
                {
                    case 'o':
                        ShowOrders();
                        break;

                    case 's':
                        ShowSales();
                        break;

                    case 'i':
                        ShowInventory();
                        break;

                    case 'u':
                        ShowUsers();
                        break;
                }
                Console.Clear();
            } while (choice != 'e');

        }
        static void ShowOrders()
        {
            while (true)
            {
                Console.Clear();
                List<Order> orderList = crud.GetActiveOrders(currLocation);
                int orderindex = 0;
                foreach (var o in orderList)
                {
                    Console.WriteLine($"({orderindex})Order\t\t\t\tTotal Cost: ${o.Cost}");
                    Console.WriteLine($"Order Status: {(OrderStatus)o.OrderStatus}\tOrder Time: {o.OrderDate}");
                    if (o.Pizza.Count == 0)
                    {
                        o.Pizza = crud.GetOrderPizzas(o);
                    }
                    foreach (var p in o.Pizza)
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine($"Pizza\t\t\t\tCost: ${p.Cost}");
                        Console.WriteLine($"Crust: {(PizzaCrust)p.Crust}\t\tSize: {(PizzaSize)p.Size}");
                        Console.WriteLine("Toppings: ");
                        if (p.PizzaTopping.Count == 0)
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
                    orderindex++;
                }
                Console.WriteLine("Select an order to set its status or type \'return\' to get back to the menu.");
                string input = Console.ReadLine();
                if (input == "return")
                    return;
                int choice;
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Please input a number.");
                    WaitForInput();
                }
                else if (choice >= orderList.Count || choice < 0)
                {
                    Console.WriteLine("Please select a valid order.");
                    WaitForInput();
                }
                else
                {
                    orderindex = choice;
                    Console.WriteLine("Select an Order Status or type \'return\' to return to the menu: ");
                    foreach (var c in Enum.GetValues(typeof(OrderStatus)))
                    {
                        Console.WriteLine($"({Convert.ToInt32(c)}) {c}");
                    }
                    input = Console.ReadLine();
                    if (input == "return")
                        return;
                    if (!int.TryParse(input, out choice))
                    {
                        Console.WriteLine("Please input a number.");
                        WaitForInput();
                    }
                    else if (Enum.IsDefined(typeof(OrderStatus), choice))
                    {
                        orderList[orderindex].OrderStatus = choice;
                        crud.UpdateOrder(orderList[orderindex]);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid Order Status.");
                        WaitForInput();
                    }
                }
            }
        }

        static void ShowSales()
        {
            Console.Clear();
            List<Order> orderList = crud.GetAllOrders(currLocation);
            decimal totalSales = 0;
            foreach(var o in orderList)
            {
                totalSales += o.Cost;
                Console.WriteLine($"{o.Username}\t\t{o.OrderDate}\t\t${o.Cost}");
            }
            Console.WriteLine($"Total Sales: ${totalSales}");
            WaitForInput();
        }

        static void ShowInventory()
        {
            Console.Clear();
            List<Inventory> invList = crud.GetInventory(currLocation);
            Topping t;
            foreach(var i in invList)
            {
                t = crud.GetTopping(i.ToppingId);
                Console.WriteLine($"{t.TopName}\t\t\t\t{i.Quantity}");
            }
            WaitForInput();
        }

        static void ShowUsers()
        {
            List<User> userList = crud.Getusers(currLocation);
            foreach(var u in userList)
            {
                Console.WriteLine($"Username: {u.Username}");
            }
            WaitForInput();
        }

        static void WaitForInput()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}