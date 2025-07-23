using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension
{
    internal class Car : Vehicle
    {
        public Car() { }

        public Car(double fuel, double consumption, double tankCapacity) : base(fuel, consumption + 0.9, tankCapacity)
        {
        }
    }
}
