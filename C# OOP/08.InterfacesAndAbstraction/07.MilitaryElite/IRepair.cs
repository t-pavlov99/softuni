using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite
{
    internal interface IRepair
    {
        string PartName { get; }

        int HoursWorked { get; }
    }
}
