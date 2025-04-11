/*
4
Blue -> dress,jeans,hat
Gold -> dress,t-shirt,boxers
White -> briefs,tanktop
Blue -> gloves
Blue dress
*/
namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(" -> ");
                if (!wardrobe.ContainsKey(cmd[0]))
                {
                    wardrobe.Add(cmd[0], new());
                }
                string[] clothes = cmd[1].Split(",");
                foreach (var item in clothes)
                {
                    if (!wardrobe[cmd[0]].ContainsKey(item))
                    {
                        wardrobe[cmd[0]].Add(item, 0);
                    }
                    wardrobe[cmd[0]][item]++;
                }
            }

            string[] value = Console.ReadLine().Split();

            foreach (var col in wardrobe)
            {
                Console.WriteLine($"{col.Key} clothes:");
                foreach (var item in col.Value)
                {
                    Console.Write($"* {item.Key} - {item.Value}");
                    if (col.Key == value[0] && item.Key == value[1])
                    {
                        Console.WriteLine(" (found!)");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
