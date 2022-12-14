using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace New_Labb_2
{
    public class Customer
    {
        public string Name { get; private set; }

        private string Password { get; set; }

        private List<Product> _cart;
        public List<Product> Cart { get { return _cart; } }
        public Customer(string name, string password)
        {
            Name = name;
            Password = password;
            _cart = new List<Product>();
        }

        public string ReturnCart()
        {
            var list = Cart.Select(x => x.Name);
            var antal = string.Empty;
            for (int i = 0; i <= list.Count(); i++)
            {
                antal = $"{i}";
            }
            return antal;
        }
        public override string ToString()
        {

            return $"Your Name: {Name}\n" +
                   $"Your Password: {Password}\n" +
                   $"Your Carts total products: {ReturnCart()}";
        }
        public bool VerifyPassword(string password)
        {
            return Password.Equals(password);
        }

        public int ReturnTotalPrice()
        {
            var totalPrice = 0;
            for (var i = 0; i < Cart.Count; i++)
            {
                totalPrice += Cart[i].Price;
            }
            return totalPrice;
        }
    }
}
