using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Beverage : Product
    {
        public double Millilitres {  get; set; }
        public Beverage(string name, decimal price, double millilitres) : base(name, price)
        {
            Millilitres = millilitres;
        }
    }
}
