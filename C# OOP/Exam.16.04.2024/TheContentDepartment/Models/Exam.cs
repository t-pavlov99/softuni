﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheContentDepartment.Models
{
    internal class Exam : Resource
    {
        public Exam(string name, string creator) : base(name, creator, 1)
        {
        }
    }
}
