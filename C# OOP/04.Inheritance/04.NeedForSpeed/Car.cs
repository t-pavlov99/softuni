﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    internal class Car : Vehicle
    {
        public override double FuelConsumption => 3;
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
    }
}
