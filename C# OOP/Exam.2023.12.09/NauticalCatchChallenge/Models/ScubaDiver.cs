using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    internal class ScubaDiver : Diver
    {
        private static int MAX_LEVEL = 540;
        public ScubaDiver(string name) : base(name, MAX_LEVEL)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel = (int)Math.Round(OxygenLevel - 0.3 * TimeToCatch, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            OxygenLevel = MAX_LEVEL;
        }
    }
}
