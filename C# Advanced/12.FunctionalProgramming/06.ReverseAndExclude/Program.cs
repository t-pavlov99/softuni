namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int divisor = int.Parse(Console.ReadLine());
            Console.WriteLine(
                string.Join(" ", numbers.Reverse().Where(x => x % divisor != 0)));
        }
    }
}
