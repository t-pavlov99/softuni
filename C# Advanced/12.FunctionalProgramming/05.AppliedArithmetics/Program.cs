namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
                else
                {
                    numbers = numbers.Select(Apply(input)).ToArray();
                }
            }
        }

        static Func<int, int> Apply(string command)
        {
            switch (command)
            {
                case "add":
                    return x => x + 1;
                case "multiply":
                    return x => x * 2;
                case "subtract":
                    return x => x - 1;
                default:
                    throw new ArgumentException(command);
            }
        }
    }
}
