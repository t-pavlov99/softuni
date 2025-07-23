using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    internal class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
            Foods = new string[] { "Meat"};
            WeightIncrease = 0.4;
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
