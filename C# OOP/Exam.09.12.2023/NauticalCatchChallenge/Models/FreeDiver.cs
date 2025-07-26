using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    internal class FreeDiver : Diver
    {
        private static int MAX_LEVEL = 120;
        public FreeDiver(string name) : base(name, MAX_LEVEL)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel = (int)Math.Round(OxygenLevel - 0.6 * TimeToCatch, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            OxygenLevel = MAX_LEVEL;
        }
    }
}
