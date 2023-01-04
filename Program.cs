using System.Runtime.Intrinsics.X86;
using System.Xml.Serialization;

namespace Shop
{
    class Program
    {
        static void Main()
        {
            Accounts accounts = new Accounts();
            Orders orders = new Orders();
            accounts = accounts.GetAccounts();
            orders = orders.GetOrders();
            
            int id = LogIn(accounts, orders);
            
            if (id == -1)
            {
                return;
            }
            shop(accounts.AccountsList[id], orders, accounts);
        }

        static int LogIn(Accounts accounts, Orders orders)
        {
            Console.Clear();
            Console.WriteLine("Welcome to our shop");
            Console.WriteLine("Print 1 if you want to enter your account");
            Console.WriteLine("Print 2 if you want to create your account");
            Console.WriteLine("Print 3 if you want to see all orders");
            Console.WriteLine("Print 4 if you want to end");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Clear();
                Console.WriteLine("Write your phone number and password");
                string password, phone_number;
                Console.Write("Phone number: ");
                phone_number = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();
                for (int i = 0; i < accounts.AccountsList.Count; i++)
                {
                    if (accounts.AccountsList[i].phone_number == phone_number &
                        accounts.AccountsList[i].password == password)
                    {
                        return i;
                    }
                }
                Console.WriteLine("This account doesn't exist");
                Console.WriteLine("Press something to continue");
                Console.ReadLine();
                return LogIn(accounts, orders);
            }
            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("Write your data");
                string name, surname, phone_number, password, card;
                Console.Write("Name: ");
                name = Console.ReadLine();
                Console.Write("Surname: ");
                surname = Console.ReadLine();
                Console.Write("Phone number: ");
                phone_number = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();
                Console.Write("Card: ");
                card = Console.ReadLine();
                
                for (int i = 0; i < accounts.AccountsList.Count; i++)
                {
                    if (accounts.AccountsList[i].phone_number == phone_number &
                        accounts.AccountsList[i].password == password)
                    {
                        Console.WriteLine("That account already exist");
                        Console.WriteLine("Press something to continue");
                        Console.ReadLine();
                        return LogIn(accounts, orders);
                    }
                }
                
                Account account = new Account(name, surname, phone_number, accounts.AccountsList.Count, password, card);
                accounts.AccountsList.Add(account);
                accounts.Save();
                return accounts.AccountsList[^1].id;
            }
            else if (choice == "3")
            {
                for (int i = 0; i < orders.OrdersList.Count; i++)
                {
                    Console.WriteLine("\nOrder {0}", i);
                    Console.WriteLine("Address {0}", orders.OrdersList[i].address);
                    Console.WriteLine("Buyer: {0} {1}", orders.OrdersList[i].buyer.Name, orders.OrdersList[i].buyer.Surname);
                    Console.WriteLine("List of bought products");
                    for (int j = 0; j < orders.OrdersList[i].products.Count; j++)
                    {
                        Console.WriteLine(orders.OrdersList[i].products[j].Name);
                    }
                }
                
                Console.WriteLine("Press something to continue");
                Console.ReadLine();
                return LogIn(accounts, orders);
            }
            else if (choice == "4")
            {
                return -1;
            }
            else
            {
                return LogIn(accounts, orders);
            }
        }
        static void shop(Account account, Orders orders, Accounts accounts)
        {
            Console.Clear();
            Console.WriteLine("Hello {0} {1}", account.Name, account.Surname);
            Console.WriteLine("You have {0}$", account.money);
            Console.WriteLine("\nPrint 1 if you want to add money to your account");
            Console.WriteLine("Print 2 if you want to buy something");
            Console.WriteLine("Print 3 if you want to back to menu");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("Do you want to use your card: " + account.card + "?");
                Console.WriteLine("y - yes\nn - no\nsomething else - exit");
                choice = Console.ReadLine();
                if (choice == "y" | choice == "Y")
                {
                    Console.WriteLine("How much $ you want to send on your account?");
                    try
                    {
                        int money = Convert.ToInt32(Console.ReadLine());
                        if (money <= 0)
                        {
                            Console.WriteLine("You can't send <= 0 amount of $ on your account");
                            Console.WriteLine("Press something to continue");
                            Console.ReadLine();
                            shop(account, orders, accounts);
                        }
                        else
                        {
                            account.money += money;
                            Console.WriteLine("You now have {0}$", account.money);
                            Console.WriteLine("Press something to continue");
                            Console.ReadLine();
                            shop(account, orders, accounts);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Write only int");
                        Console.WriteLine("Press something to continue");
                        Console.ReadLine();
                        shop(account, orders, accounts);
                    }
                }
                else if (choice == "n" | choice == "N")
                {
                    Console.WriteLine("Write your new card: ");
                    string new_card = Console.ReadLine();
                    Console.WriteLine("Do you want to save card {0} as your main?", new_card);
                    Console.WriteLine("y - yes\nn - no\nsomething else - exit");
                    choice = Console.ReadLine();
                    if (choice == "y" | choice == "Y")
                    {
                        account.card = new_card;
                        Console.WriteLine("How much $ you want to send on your account?");
                        try
                        {
                            int money = Convert.ToInt32(Console.ReadLine());
                            if (money <= 0)
                            {
                                Console.WriteLine("You can't send <= 0 amount of $ on your account");
                                Console.WriteLine("Press something to continue");
                                Console.ReadLine();
                                shop(account, orders, accounts);
                            }
                            else
                            {
                                account.money += money;
                                Console.WriteLine("You now have {0}$", account.money);
                                Console.WriteLine("Press something to continue");
                                Console.ReadLine();
                                shop(account, orders, accounts);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Write only int");
                            Console.WriteLine("Press something to continue");
                            Console.ReadLine();
                            shop(account, orders, accounts);
                        }
                    }
                    else if (choice == "n" | choice == "N")
                    {
                        Console.WriteLine("How much $ you want to send on your account?");
                        try
                        {
                            int money = Convert.ToInt32(Console.ReadLine());
                            if (money <= 0)
                            {
                                Console.WriteLine("You can't send <= 0 amount of $ on your account");
                                Console.WriteLine("Press something to continue");
                                Console.ReadLine();
                                shop(account, orders, accounts);
                            }
                            else
                            {
                                account.money += money;
                                Console.WriteLine("You now have {0}$", account.money);
                                Console.WriteLine("Press something to continue");
                                Console.ReadLine();
                                shop(account, orders, accounts);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Write only int");
                            Console.WriteLine("Press something to continue");
                            Console.ReadLine();
                            shop(account, orders, accounts);
                        }
                    }
                }
                else
                {
                    shop(account, orders, accounts);
                }
            }
            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("Write your address: ");
                choice = Console.ReadLine();
                Order order = new Order(choice, account);
                ProductInShop productInShop = new ProductInShop();

                choice = "y";
                while (choice == "y" | choice == "Y")
                {
                    Console.Clear();
                    Console.WriteLine("Products you have chosen");
                    int cost = 0;
                    for (int i = 0; i < order.products.Count; i++)
                    {
                        Console.WriteLine("{0}: cost {1}$", order.products[i].Name, order.products[i].cost);
                        cost += order.products[i].cost;
                    }
                    Console.WriteLine("Money you have: {0}$", account.money);
                    Console.WriteLine("Cost of the order: {0}$", cost);

                    Console.WriteLine("\nProducts you can choose");
                    Console.WriteLine("{0}: cost {1}$, id {2}", productInShop.copybook.Name, productInShop.copybook.cost, 0);
                    Console.WriteLine("{0}: cost {1}$, id {2}", productInShop.glue.Name, productInShop.glue.cost, 1);
                    Console.WriteLine("{0}: cost {1}$, id {2}", productInShop.paper.Name, productInShop.paper.cost, 2);
                    Console.WriteLine("{0}: cost {1}$, id {2}", productInShop.pencils.Name, productInShop.pencils.cost, 3);
                    Console.WriteLine("{0}: cost {1}$, id {2}", productInShop.pens.Name, productInShop.pens.cost, 4);
                    Console.WriteLine("{0}: cost {1}$, id {2}", productInShop.tape.Name, productInShop.tape.cost, 5);
                    Console.WriteLine("{0}: cost {1}$, id {2}", productInShop.scissors.Name, productInShop.scissors.cost, 6);

                    Console.WriteLine("Do you want to add something to order?");
                    Console.WriteLine("y - yes\nsomething else - exit");
                    choice = Console.ReadLine();
                    if (choice == "y" | choice == "Y")
                    {
                        Console.WriteLine("Write index (id) of product you want to buy");
                        string id = Console.ReadLine();
                        Console.WriteLine("ID: " + id);
                        if (id == "0")
                        {
                            order.products.Add(productInShop.copybook);
                        }
                        else if (id == "1")
                        {
                            order.products.Add(productInShop.glue);
                        }
                        else if (id == "2")
                        {
                            order.products.Add(productInShop.paper);
                        }
                        else if (id == "3")
                        {
                            order.products.Add(productInShop.pencils);
                        }
                        else if (id == "4")
                        {
                            order.products.Add(productInShop.pens);
                        }
                        else if (id == "5")
                        {
                            order.products.Add(productInShop.tape);
                        }
                        else if (id == "6")
                        {
                            order.products.Add(productInShop.scissors);
                        }
                        else
                        {
                            Console.WriteLine("Product is not found");
                            Console.WriteLine("Press something to continue");
                            Console.ReadLine();
                        }
                    }
                }
                
                Console.Clear();
                int cost_final = 0;
                for (int i = 0; i < order.products.Count; i++)
                {
                    cost_final += order.products[i].cost;
                }

                if (cost_final > account.money)
                {
                    Console.WriteLine("You don't have enough money");
                    Console.WriteLine("Press something to continue");
                    Console.ReadLine();
                    shop(account, orders, accounts);
                    return;
                }
                Console.WriteLine("You ordered");
                for (int i = 0; i < order.products.Count; i++)
                {
                    Console.WriteLine("{0}: cost {1}$", order.products[i].Name, order.products[i].cost);
                }
                Console.WriteLine("Final cost of your order is {0}$", cost_final);
                Console.WriteLine("\nDo you want to buy it?");
                Console.WriteLine("y - yes\nsomething else - no");
                choice = Console.ReadLine();
                if (choice == "y" & order.products.Count != 0)
                {
                    account.money -= cost_final;
                    orders.OrdersList.Add(order);
                    orders.Save();
                }
                shop(account, orders, accounts);
            }
            else if (choice == "3")
            {
                Main();
            }
            else
            {
                shop(account, orders, accounts);
            }
        }
    }
}