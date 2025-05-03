namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static Predicate<int> IsEven = x => x % 2 == 0;

        static Predicate<int> Check(string type)
        {
            switch (type)
            {
                case "even": return x => IsEven(x);
                case "odd": return x => !IsEven(x);
                default:
                    throw new ArgumentException();
            }
        }
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            int start = int.Parse(input[0]);
            int end = int.Parse(input[1]);
            string type = Console.ReadLine();
            for (int i = start; i <= end; i++)
            {
                if (Check(type)(i))
                {
                    Console.Write($"{i} ");
                }
            }


        }
    }
}
