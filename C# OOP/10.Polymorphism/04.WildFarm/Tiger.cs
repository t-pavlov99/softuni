using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    internal class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            Foods = new string[] { "Meat" };
            WeightIncrease = 1.0;
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
