using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    internal abstract class Animal
    {
        public string[] Foods { get; protected set; }

        public double WeightIncrease { get; protected set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public void Eat(Food food)
        {
            if (Foods.Contains(food.GetType().Name))
            {
                Weight += food.Quantity * WeightIncrease;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new Exception($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
        public abstract string ProduceSound();
    }
}
