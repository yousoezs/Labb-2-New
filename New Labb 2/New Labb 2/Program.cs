using static System.Console;

namespace New_Labb_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>() { new("Knatte", "123"), new("Fnatte", "321"), new("Tjatte", "213") };
            Product Korv = new("Korv", 150);
            Product Bröd = new("Korv bröd", 200);
            Product Ketchup = new("Ketchup", 300);

            Customer? currentCustomer = null;
            loggedOut:

            while (currentCustomer == null)
            {
                Clear();
                WriteLine("Welcome, Choose one of the following options!");
                WriteLine("1. Login\n2. Register\n3. Terminate");
                ConsoleKeyInfo key = ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        {
                            Clear();
                            WriteLine("Enter your username!");
                            string input = ReadLine();
                            var user = customers.FirstOrDefault(x => x.Name == input);
                            if (user == null)
                            {
                                WriteLine("No registered user exists, if you wish to create one, type \"Create\"!\nOr type in a empty string to try again.");
                                if (ReadLine() == "Create")
                                {
                                    goto case ConsoleKey.D2;
                                }
                                break;
                            }

                            WriteLine("User exists...\nType password\n------------------------------");
                            while (currentCustomer == null)
                            {
                                string passW = ReadLine();
                                if (user.VerifyPassword(passW))
                                {
                                    currentCustomer = user;
                                }
                                else
                                {
                                    WriteLine("Wrong password entered!");
                                    WriteLine("Try again!");
                                }
                            }

                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            try
                            {
                                Clear();
                                WriteLine("Create a username!");
                                string input = ReadLine();
                                WriteLine("Enter a password!");
                                string passW = ReadLine();
                                Customer newCustomer = new(input, passW);
                                customers.Add(newCustomer);
                                WriteLine($"Good job {input}. Now try and login!");
                                break;
                            }
                            catch (Exception e)
                            {
                                WriteLine("Something went wrong...");
                                continue;
                            }
                        }
                    case ConsoleKey.D3:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
            WriteLine($"Welcome {currentCustomer}");
            while (currentCustomer != null)
            {
                Clear();
                WriteLine($"Welcome {currentCustomer}.\nChoose one of the following you wish to do!");
                WriteLine("1. Enter the Store\n" +
                          "2. See Cart\n" +
                          "3. Go to Checkout\n" +
                          "4. Log out.");
                ConsoleKeyInfo key = ReadKey();
                var antalKorv = currentCustomer.Cart.Where(x => x.Name == "Korv");
                var antalBröd = currentCustomer.Cart.Where(x => x.Name == "Korv bröd");
                var antalKetchup = currentCustomer.Cart.Where(x => x.Name == "Ketchup");
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        {
                            Clear();
                            WriteLine("Available Products below...\n" +
                                      $"1. {Korv} {Korv.Price}SEK\n" +
                                      $"2. {Bröd} {Bröd.Price}SEK\n" +
                                      $"3. {Ketchup} {Ketchup.Price}SEK\n" +
                                       "4. Go Back.");
                            while (key.Key != ConsoleKey.D4)
                            {
                                ConsoleKeyInfo key2 = ReadKey();
                                if (key2.Key == ConsoleKey.D1)
                                {
                                    currentCustomer.Cart.Add(Korv);
                                    WriteLine($"You now have {antalKorv.Count()} of Korv");
                                }
                                else if (key2.Key == ConsoleKey.D2)
                                {
                                    currentCustomer.Cart.Add(Bröd);
                                    WriteLine($"You now have {antalBröd.Count()} of Bröd");
                                }
                                else if (key2.Key == ConsoleKey.D3)
                                {
                                    currentCustomer.Cart.Add(Ketchup);
                                    WriteLine($"You now have {antalKetchup.Count()} of Ketchup");
                                }
                                else if (key2.Key == ConsoleKey.D4)
                                {
                                    WriteLine("Going back...");
                                    break;
                                }
                            }
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            Clear();
                            WriteLine("Here is your Cart...");
                            WriteLine("---------------------");
                            WriteLine($"Korv A-Pris: {Korv.Price}SEK | Antal Korv: {antalKorv.Count()} Pris för Korvar: {antalKorv.Count() * Korv.Price}SEK\nBröd A-pris: {Bröd.Price}SEK | Antal Bröd: {antalBröd.Count()} Pris för bröd: {antalBröd.Count() * Bröd.Price}SEK\nKetchup A-Pris: {Ketchup.Price}SEK | Antal Ketchup: {antalKetchup.Count()} Pris för Ketchupar: {antalKetchup.Count() * Ketchup.Price}SEK");
                            WriteLine($"The total cost of your cart is: {currentCustomer.ReturnTotalPrice()}");
                            WriteLine("If you wish to head back press any key...");
                            ReadKey();
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            WriteLine($"Do you wish to checkout? {currentCustomer}.\nType \"Yes\" or \"No\".");
                            if (ReadLine() == "Yes")
                            {
                                WriteLine("Bye bye!");
                                currentCustomer.Cart.Clear();
                                currentCustomer = null;
                                goto loggedOut;
                            }
                            else if (ReadLine() == "No")
                            {
                                WriteLine("You may continue...");
                            }

                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            WriteLine($"Logging {currentCustomer.Name} out.");
                            currentCustomer = null;
                            goto loggedOut;
                        }
                    default:
                        WriteLine("something went wrong...");
                        break;
                }
            }
        }
    }
}