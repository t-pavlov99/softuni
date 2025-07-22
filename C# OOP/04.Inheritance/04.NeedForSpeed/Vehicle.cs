using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    internal class Vehicle
    {
        public double DefaultFuelConsumption { get => this.FuelConsumption; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public virtual double FuelConsumption { get => 1.25;}

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public virtual void Drive(double kilometers)
        {
            Fuel = Math.Max(0, Fuel - kilometers * DefaultFuelConsumption);
        }
    }
}
