namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> table = new();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split().ToArray();
                foreach (string p in parts)
                {
                    table.Add(p);
                }
            }

            Console.WriteLine(string.Join(" ", table));
        }
    }
}
