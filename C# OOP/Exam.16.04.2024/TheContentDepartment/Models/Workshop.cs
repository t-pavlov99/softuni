﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheContentDepartment.Models
{
    internal class Workshop : Resource
    {
        public Workshop(string name, string creator) : base(name, creator, 2)
        {
        }
    }
}
