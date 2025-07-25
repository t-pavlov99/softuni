﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class Person
    {
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired()]
        public string FullName { get; set; }

        [MyRange(12, 90)]
        public int Age { get; set; }
    }
}
