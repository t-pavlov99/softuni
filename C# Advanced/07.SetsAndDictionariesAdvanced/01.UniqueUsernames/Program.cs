namespace _01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> users = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                users.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join("\n", users));

        }
    }
}
