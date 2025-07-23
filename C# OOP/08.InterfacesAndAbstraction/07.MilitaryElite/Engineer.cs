using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite
{
    internal class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            repairs = new List<IRepair>();
        }

        private List<IRepair> repairs;
        public IReadOnlyCollection<IRepair> Repairs { get => repairs.AsReadOnly(); }

        public void AddRepair(IRepair repair)
        {
            repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append("Repairs:");
            foreach (IRepair repair in repairs)
            {
                sb.Append($"\n  {repair.ToString()}");
            }
            return sb.ToString();
        }
    }
}
