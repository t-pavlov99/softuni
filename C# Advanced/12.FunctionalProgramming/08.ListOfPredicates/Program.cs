namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] divisors = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            List<int> numbers = new List<int>(n);
            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);

            }
            foreach (int divisor in divisors)
            {
                numbers = numbers.Where(Check(divisor)).ToList();
            }
            Console.WriteLine(string.Join(" ", numbers));

        }

        static Func<int, bool> Check(int n)
        {
            return x => x % n == 0;
        }
    }
}
