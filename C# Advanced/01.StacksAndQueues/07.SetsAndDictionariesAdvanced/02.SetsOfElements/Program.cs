namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> first = new(), second = new();
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < sizes[0]; i++)
            {
                first.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < sizes[1]; i++)
            {
                second.Add(int.Parse(Console.ReadLine()));
            }
            foreach (int number in first)
            {
                if (second.Contains(number))
                    Console.Write($"{number} ");
            }
        }
    }
}
