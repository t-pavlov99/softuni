﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    public class Citizen : IPerson
    {
        public string Name { get; set; }
        public int Age {  get; set; }

        public Citizen(string name, int age)
        {
            Name = name;
            Age = age;
        }

    }
}
