using _04.BorderControl;
namespace _06.FoodShortage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            Dictionary<string, IBuyer> list = new Dictionary<string, IBuyer> ();
            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                switch (input.Length)
                {
                    case 3: list.Add(input[0], new Rebel(input[0], int.Parse(input[1]), input[2])); break;
                    case 4: list.Add(input[0], new Citizen(input[2], input[0], int.Parse(input[1]), input[3])); break;
                }
            }
            string name;
            while ((name = Console.ReadLine()) != "End")
            {
                if (list.ContainsKey(name))
                    list[name].BuyFood();
            }
            Console.WriteLine(list.Values.Select(x => x.Food).Sum());

        }
    }
}
