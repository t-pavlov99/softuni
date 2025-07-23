using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl
{
    internal class Citizen : IIdentifiable
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Citizen(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
}
