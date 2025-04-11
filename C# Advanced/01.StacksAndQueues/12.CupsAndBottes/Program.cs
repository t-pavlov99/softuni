/*
4 2 10 5
3 15 15 11 6

1 5 28 1 4
3 18 1 9 30 4 5

10 20 30 40 50
20 11
*/
namespace _12.CupsAndBottes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new(Console.ReadLine().Split(" ").Select(int.Parse));
            Stack<int> bottles = new(Console.ReadLine().Split(" ").Select(int.Parse));

            int wastedWater = 0;
            int filled = 0;

            while (cups.Count != 0 && bottles.Count != 0)
            {
                int bottle = bottles.Pop();
                if (filled + bottle < cups.Peek())
                {
                    filled += bottle;
                }
                else
                {
                    wastedWater += filled + bottle - cups.Dequeue();

                    filled = 0;
                }
            }
            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: " + string.Join(" ", bottles));
            }
            else
            {
                Console.WriteLine($"Cups: " + string.Join(" ", cups));
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
