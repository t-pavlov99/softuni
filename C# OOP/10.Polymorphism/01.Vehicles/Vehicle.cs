using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    internal abstract class Vehicle
    {
        public double Fuel { get; protected set; }
        public double Consumption { get; private set; }
        public double DistanceDriven { get; private set; }
        public Vehicle()
        {
            this.DistanceDriven = 0;
        }

        public Vehicle(double fuel, double consumption) : this()
        {
            this.Fuel = fuel;
            this.Consumption = consumption;
        }

        public virtual void Refuel(double fuel)
        {
            this.Fuel += fuel;
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
