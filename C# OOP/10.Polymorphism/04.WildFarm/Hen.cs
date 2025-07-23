using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    internal class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
            Foods = new string[]{ "Vegetable", "Fruit", "Meat", "Seeds"};
            WeightIncrease = 0.35;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
