﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Cake : Dessert
    {
        public Cake(string name) : base(name, 5, 250, 1000)
        {
        }
    }
}
