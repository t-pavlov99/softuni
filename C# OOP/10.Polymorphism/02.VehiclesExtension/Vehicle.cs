using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension
{
    internal abstract class Vehicle
    {
        public double Fuel { get; protected set; }
        public double Consumption { get; protected set; }
        public double DistanceDriven { get; protected set; }

        public double TankCapacity { get; protected set; }
        public Vehicle()
        {
            this.DistanceDriven = 0;
        }

        public Vehicle(double fuel, double consumption, double tankCapacity) : this()
        {
            this.Consumption = consumption;
            this.TankCapacity = tankCapacity;
            this.Fuel = fuel > tankCapacity ? 0 : fuel;
        }

        public virtual bool Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                return false;
            }
            if (this.Fuel + fuel > this.TankCapacity)
            {
                throw new Exception($"Cannot fit {fuel} fuel in the tank");
            }
            this.Fuel += fuel;
            this.Fuel = Math.Min(this.Fuel, TankCapacity);
            return true;
        }

        public virtual bool Drive(double distance)
        {
            if (distance * Consumption <= Fuel)
            {
                this.Fuel -= distance * Consumption;
                this.DistanceDriven += distance;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Fuel:f2}";
        }
    }
}
