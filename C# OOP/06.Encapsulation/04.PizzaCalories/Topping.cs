using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    internal class Topping
    {
        public Topping(string type, decimal weight)
        {
            Type = type;
            Weight = weight;
        }
        private static Dictionary<string, decimal> types = new Dictionary<string, decimal>
            { { "meat", 1.2m }, { "veggies", 0.8m }, { "cheese", 1.1m }, { "sauce", 0.9m } };
        private string type;
        private decimal weight;
        public string Type
        {
            get => type;
            private set
            {
                if (!types.ContainsKey(value.ToLower()))
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                type = value;
            }
        }

        public decimal Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                weight = value;
            }
        }

        public decimal Calories
        {
            get => 2m * weight * types[type.ToLower()];
        }
    }
}
