using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 
Car 30.4 0.4
Truck 99.34 0.9
5
Drive Car 500
Drive Car 13.5
Refuel Truck 10.300
Drive Truck 56.2
Refuel Car 100.2
 */
namespace _01.Vehicles
{
    internal class Truck : Vehicle
    {
        public Truck()
        {
        }

        public Truck(double fuel, double consumption) : base(fuel, consumption + 1.6)
        {
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * .95);
            //Fuel *= 0.95m;
        }
    }
}
