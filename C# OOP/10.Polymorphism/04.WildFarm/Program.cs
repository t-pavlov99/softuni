/*\
Cat Sammy 1.1 Home Persian
Vegetable 4
End

Tiger Rex 167.7 Asia Bengal
Vegetable 1
Dog Tommy 500 Street
Vegetable 150
End

Mouse Jerry 0.5 Anywhere
Fruit 1000
Owl Tom 2.5 30
Meat 5
End
 */
namespace _04.WildFarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            bool even = true;
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                switch (even)
                {
                    case true:
                        animals.Add(CreateAnimal(input));
                        break;
                    case false:
                        Food food = CreateFood(input);
                        Console.WriteLine(animals.Last().ProduceSound());
                        try
                        {
                            animals[animals.Count - 1].Eat(food);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
                even = !even;
            }
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        public static Animal CreateAnimal(string info)
        {
            string[] parts = info.Split();
            string type = parts[0];
            string name = parts[1];
            double weight = double.Parse(parts[2]);
            string info1 = parts[3];
            switch (parts[0])
            {
                case "Hen": return new Hen(name, weight, double.Parse(info1));
                case "Owl": return new Owl(name, weight, double.Parse(info1));
                case "Cat": return new Cat(name, weight, info1, parts[4]);
                case "Tiger": return new Tiger(name, weight, info1, parts[4]);
                case "Mouse": return new Mouse(name, weight, info1);
                case "Dog": return new Dog(name, weight, info1);
                default: throw new Exception("Invalid animal!");
            }
        }

        public static Food CreateFood(string info)
        {
            string[] parts = info.Split();
            string type = parts[0];
            int quantity = int.Parse(parts[1]);
            switch (parts[0])
            {
                case "Vegetable": return new Vegetable(quantity);
                case "Fruit": return new Fruit(quantity);
                case "Seeds": return new Seeds(quantity);
                case "Meat": return new Meat(quantity);
                default: throw new Exception("Invalid food!");
            }
        }
    }
}
