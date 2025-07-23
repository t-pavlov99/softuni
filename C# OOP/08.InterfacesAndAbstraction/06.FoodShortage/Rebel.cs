using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FoodShortage
{
    internal class Rebel : IBuyer
    {
        public string Group { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Food { get; set; }

        public Rebel(string name, int age, string group)
        {
            Group = group;
            Name = name;
            Age = age;
            Food = 0;
        }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
