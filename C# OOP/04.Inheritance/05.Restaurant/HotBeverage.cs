﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class HotBeverage : Beverage
    {
        public HotBeverage(string name, decimal price, double millilitres) : base(name, price, millilitres)
        {
        }
    }
}
