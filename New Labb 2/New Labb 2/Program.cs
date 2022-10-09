using static System.Console;

namespace New_Labb_2
{
    /*Skapa en konsollaplikation som skall agera som en enkel affär.
     När programmet körs så ska man få se någon form av meny där man ska kunna välja att registrera ny kund eller logga in. 
    Därefter ska ytterligare en meny visas där man ska kunna välja att handla, se kundvagn eller gå till kassan.
    Om man väljer att handla ska man få upp minst 3 olika produkter att köpa (t.ex. Korv, Dricka och Äpple). 
    Man ska se pris för varje produkt och kunna lägga till vara i kundvagn.
    Kundvagnen ska visa alla produkter man lagt i den, styckpriset, antalet och totalpriset samt totala kostnaden för hela kundvagnen. 
    Kundvagnen skall sparas i kund och finnas tillgänglig när man loggar in.
    När man ska Registrera en ny kund ska man ange Namn och lösenord. Dessa ska sparas och namnet ska inte gå att ändra.
    Väljer man Logga In så ska man skriva in namn och lösenord. 
    Om användaren inte finns registrerad ska programmet skriva ut att kunden inte finns och fråga ifall man vill registrera ny kund. 
    Om lösenordet inte stämmer så ska programmet skriva ut att lösenordet är fel och låta användaren försöka igen.
    Både kund och produkt ska vara separata klasser med Properties för information och metoder för att räkna ut totalpris och verifiera lösenord.
    I klassen Kund skall det finnas en ToString() som skriver ut Namn, lösenord och kundvagnen på ett snyggt sätt.

Exempel:

    public class Customer 
    {
        public string Name { get; private set; }

        private string Password { get; set }

        private List<Product> _cart;
        public List<Product> Cart { get { return _cart; } }

        public Kund(string name, string password)
        {
            Name = name;
            Password = password;
            _cart = new List<Product>();
        }
    }*/

    /*Inputs... A Customer login/register. A cart in Customer class that takes a list of products. A Class of Product.
      And saving product in Customer Cart.
      Complex Inputs... Method for login at Customer Class. Method for adding products in Customer Cart. Method for total price in cart.
      Method for verification of password.
      Output... Several menus for navigation. Login, Register, Shop/Products. Cart and also Checkout.
    
      3 Classes, Customer Class, Product Class, and Program. Customer Class will hold Login method, and a method for checking if user is logged in.
      Method for adding products.
      Product Class with hold a general value for creating products with a name and a price.
      Program will hold the menus.*/
    internal class Program
    {
        private
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
                                WriteLine("No registered user exists, if you wish to create one, type \"Create\"!");
                                if (ReadLine() == "Create")
                                {
                                    goto case ConsoleKey.D2;
                                }
                                ReadKey();
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
                                      $"1. {Korv} {Korv.Price}\n" +
                                      $"2. {Bröd} {Bröd.Price}\n" +
                                      $"3. {Ketchup} {Ketchup.Price}\n" +
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


                            WriteLine($"Korv A-Pris: {Korv.Price} | Antal Korv: {antalKorv.Count()}\nBröd A-pris: {Bröd.Price} | Antal Bröd: {antalBröd.Count()}\nKetchup A-Pris: {Ketchup.Price} | Antal Ketchup: {antalKetchup.Count()}");

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
                                currentCustomer = null;
                                Environment.Exit(0);
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