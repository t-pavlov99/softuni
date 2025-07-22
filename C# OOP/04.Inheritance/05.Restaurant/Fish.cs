using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Fish : MainDish
    {
        public Fish(string name, decimal price) : base(name, price, 22)
        {
        }
    }
}
