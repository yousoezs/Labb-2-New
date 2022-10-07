using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Labb_2
{
    public class Product
    {
        private int _price;
        private string _name;

        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public Product(string Name, int Price)
        {
            _price = Price;
            _name = Name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
