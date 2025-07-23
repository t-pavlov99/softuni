using _04.BorderControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BirthdayCelebrations
{
    internal class Pet : IBirthable
    {
        public string Birthdate {  get; set; }
        public string Name { get; set; }

        public Pet(string birthdate, string name)
        {
            Birthdate = birthdate;
            Name = name;
        }
    }
}
