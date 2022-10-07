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
            List<Customer> customers = new List<Customer>();

            Customer Knatte = new("Knatte", "123");
            Customer Fnatte = new("Fnatte", "321");
            Customer Tjatte = new("Tjatte", "213");

            Product Korv = new("Korv", 150);
            Product Bröd = new("Korv bröd", 200);
            Product Ketchup = new("Ketchup", 300);

            customers.Add(Knatte);
            customers.Add(Fnatte);
            customers.Add(Tjatte);

            Customer? currentCustomer = null;


            while (currentCustomer == null)
            {
                Clear();
                WriteLine("Welcome, Choose one of the following options!");
                WriteLine("1. Login\n2. Register");
                ConsoleKeyInfo key = ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        {
                            Clear();
                            WriteLine("Enter your username!");
                            string input = ReadLine();
                            var user = customers.FirstOrDefault(x => x.Name == input);
                            string passW = ReadLine();
                            if (user.VerifyPassword(passW))
                            {
                                currentCustomer = user;
                            }
                            else
                            {
                                WriteLine("Wrong password entered!");
                                WriteLine("Try again!");
                                ReadKey();
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
                                WriteLine("No Numbers!");
                                continue;
                            }
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
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        {
                            int countK = 0;
                            int countB = 0;
                            int countKE = 0;
                            Clear();
                            WriteLine("Available Products below...\n" +
                                      $"1. {Korv} 150 SEK\n" +
                                      $"2. {Bröd} 200 SEK\n" +
                                      $"3. {Ketchup} 300 SEK\n" +
                                       "4. Go Back.");
                            while (key.Key != ConsoleKey.D4)
                            {
                                ConsoleKeyInfo key2 = ReadKey();
                                if (key2.Key == ConsoleKey.D1)
                                {
                                    countK++;
                                    currentCustomer.Cart.Add(Korv);
                                    WriteLine($"You now have {countK} of Korv");
                                }
                                else if (key2.Key == ConsoleKey.D2)
                                {
                                    countB++;
                                    currentCustomer.Cart.Add(Bröd);
                                    WriteLine($"You now have {countB} of Bröd");
                                }
                                else if (key2.Key == ConsoleKey.D3)
                                {
                                    countKE++;
                                    currentCustomer.Cart.Add(Ketchup);
                                    WriteLine($"You now have {countKE} of Ketchup");
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
                            WriteLine("Here is your Cart...\n");
                            string listOutput = String.Join(",", currentCustomer.Cart);
                            WriteLine($"{listOutput}");
                            ReadKey();
                            break;
                        }

                }
            }
        }
    }
}