using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension
{
    internal class Bus : Vehicle
    {
        public Bus()
        {
        }

        public Bus(double fuel, double consumption, double tankCapacity) : base(fuel, consumption, tankCapacity)
        {
        }

        public bool Drive(bool withPeople, double distance)
        {
            if (withPeople)
            {
                Consumption += 1.4;
                bool success = base.Drive(distance);
                Consumption -= 1.4;
                return success;
            }
            return base.Drive(distance);
            
        }

        public override bool Drive(double distance)
        {
            return this.Drive(true, distance);
        }
    }
}
