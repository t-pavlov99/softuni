using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Food : Product
    {
        public double Grams { get; set; }
        public Food(string name, decimal price, double grams) : base(name, price)
        {
            Grams = grams;
        }
    }
}
