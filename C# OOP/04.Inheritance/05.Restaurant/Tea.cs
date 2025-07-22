using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Tea : HotBeverage
    {
        public Tea(string name, decimal price, double millilitres) : base(name, price, millilitres)
        {
        }
    }
}
