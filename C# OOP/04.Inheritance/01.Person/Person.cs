﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
        public Person(string name, int age)

        {

            this.Name = name;

            this.Age = age;

        }

        public override string ToString()

        {

            StringBuilder stringBuilder = new StringBuilder();


            stringBuilder.Append(String.Format("{0} -> ",

            this.GetType().Name));

            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",

            this.Name,

            this.Age));


            return stringBuilder.ToString();

        }
    }
}
