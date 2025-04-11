namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> info = new();
            for (int i = 0; i < n; i++)
            {
                int k = int.Parse(Console.ReadLine());
                if (!info.ContainsKey(k))
                {
                    info.Add(k, 0);
                }
                info[k]++;
            }
            foreach (var c in info)
            {
                if (c.Value % 2 == 0)
                {
                    Console.WriteLine(c.Key);
                    return;
                }
            }
        }
    }
}
