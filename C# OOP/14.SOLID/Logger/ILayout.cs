﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal interface ILayout
    {
        string Compose(Log log);
    }
}
