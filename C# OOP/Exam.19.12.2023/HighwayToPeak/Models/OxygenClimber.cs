﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    internal class OxygenClimber : Climber
    {
        public OxygenClimber(string name) : base(name, 10)
        {
        }

        public override void Rest(int daysCount)
        {
            Stamina += daysCount;
        }
    }
}
