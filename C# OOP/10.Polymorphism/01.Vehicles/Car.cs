using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    internal class Car : Vehicle
    {
        public Car() { }

        public Car(double fuel, double consumption) : base(fuel, consumption + 0.9)
        {
        }
    }
}
