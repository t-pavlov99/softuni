using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    internal class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
            Foods = new string[] { "Vegetable", "Fruit"};
            WeightIncrease = 0.1;
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
