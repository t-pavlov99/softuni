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
namespace _02.VehiclesExtension
{
    internal class Truck : Vehicle
    {
        public Truck()
        {
        }

        public Truck(double fuel, double consumption, double tankCapacity) : base(fuel, consumption + 1.6, tankCapacity)
        {
        }

        public override bool Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                return false;
            }
            if (this.Fuel + fuel * 0.95 > this.TankCapacity)
            {
                throw new Exception($"Cannot fit {fuel} fuel in the tank");
            }
            this.Fuel += fuel * 0.95;
            this.Fuel = Math.Min(this.Fuel, TankCapacity);
            return true;
        }
    }
}
