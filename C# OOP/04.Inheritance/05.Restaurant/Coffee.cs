﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Coffee : HotBeverage
    {
        public const double CoffeeMilliliters = 50d;

        public const decimal CoffeePrice = 3.50m;

        public double Caffeine { get; set; }
        public Coffee(string name, double caffeine) : base(name, CoffeePrice, CoffeeMilliliters)
        {
            Caffeine = caffeine;
        }
    }
}
