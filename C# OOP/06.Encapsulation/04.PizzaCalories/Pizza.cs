using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    internal class Pizza
    {
        public Pizza(string name, Dough dough) {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length == 0 || value.Length > 15)
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                name = value;
            }
        }
        public Dough Dough { get { return dough; } set { dough = value; } }

        //public IReadOnlyCollection<Topping> Toppings { get { return toppings.AsReadOnly(); } }

        public int NumberOfToppings { get =>  toppings.Count; }
        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
                throw new Exception("Number of toppings should be in range [0..10].");
            toppings.Add(topping);
        }

        public decimal Calories
        {
            get => Dough.Calories + toppings.Select(x => x.Calories).Sum();
        }

        public override string ToString()
        {
            return $"{name} - {Calories:f2} Calories.";
        }
    }
}
