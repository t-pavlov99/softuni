using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite
{
    internal abstract class SpecialisedSoldier : RegularSoldier, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        private string corps;
        public string Corps {
            get => corps;
            set
            {
                if (value != "Airforces" && value != "Marines")
                    throw new ArgumentException("Invalid corps.");
                corps = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCorps: {Corps}";
        }
    }
}
