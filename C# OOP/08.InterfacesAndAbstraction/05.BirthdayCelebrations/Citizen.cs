using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl
{
    internal class Citizen : IIdentifiable, IBirthable
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Birthdate { get; set; }
        public Citizen(string id, string name, int age, string birthdate)
        {
            Id = id;
            Name = name;
            Age = age;
            Birthdate = birthdate;
        }
    }
}
