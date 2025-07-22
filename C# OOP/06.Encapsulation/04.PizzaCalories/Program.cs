using _04.PizzaCalories;
/*
Pizza Bulgarian
Dough White Chewy 100
Topping Sirene 50
Topping Cheese 50
Topping Krenvirsh 20
Topping Meat 10
END
*/
namespace _04.PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string[] names = Console.ReadLine().Split(" ");
                string name = names[1];
                string[] doughInfo = Console.ReadLine().Split(" ");
                Pizza pizza = new Pizza(name, new Dough(doughInfo[1], doughInfo[2], decimal.Parse(doughInfo[3])));
                string info;
                while ((info = Console.ReadLine()) != "END")
                {
                    string[] parts = info.Split(" ");
                    pizza.AddTopping(new Topping(parts[1], decimal.Parse(parts[2])));
                }
                Console.WriteLine(pizza.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
