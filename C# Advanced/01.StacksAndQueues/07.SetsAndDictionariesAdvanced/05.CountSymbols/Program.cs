namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> occurences = new();
            string text = Console.ReadLine();
            foreach (char c in text)
            {
                if (!occurences.ContainsKey(c))
                {
                    occurences.Add(c, 0);
                }
                occurences[c]++;
            }
            Console.WriteLine(string.Join("\n", occurences.Select(a => $"{a.Key}: {a.Value} time/s")));
        }
    }
}
