﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite
{
    internal interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }
}
