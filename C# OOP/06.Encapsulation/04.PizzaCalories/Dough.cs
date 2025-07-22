using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    internal class Dough
    {
        public Dough(string flourType, string bakingTechnique, decimal weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }
        private Dictionary<String, decimal> types = new Dictionary<String, decimal> { { "white", 1.5m }, { "wholegrain", 1.0m } };
        private Dictionary<String, decimal> techniques = new Dictionary<String, decimal> { { "crispy", 0.9m }, { "chewy", 1.1m }, { "homemade", 1.0m} };
        private string flourType;
        private string bakingTechnique;
        private decimal weight;

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (!types.ContainsKey(value.ToLower()))
                    throw new ArgumentException("Invalid type of dough.");
                flourType = value.ToLower();
            }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (!techniques.ContainsKey(value.ToLower()))
                    throw new ArgumentException("Invalid type of dough.");
                bakingTechnique = value.ToLower();
            }
        }
        public decimal Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 200)
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                weight = value;
            }
        }

        public decimal Calories
        {
            get => 2m * weight * types[flourType] * techniques[bakingTechnique];
        }


    }
}
