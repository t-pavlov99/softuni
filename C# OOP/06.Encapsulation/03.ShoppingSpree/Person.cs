using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShoppingSpree
{
    internal class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;
        public string Name
        {

            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                    throw new ArgumentException("Name cannot be empty");
                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public IReadOnlyCollection<Product> Products
        {
            get { return products.AsReadOnly(); }
        }

        public void AddProduct(Product product)
        {
            if (money < product.Cost)
            {
                Console.WriteLine($"{name} can't afford {product.Name}");
                return;
            }
            products.Add(product);
            money -= product.Cost;
            Console.WriteLine($"{name} bought {product.Name}");
        }

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

    }
}
