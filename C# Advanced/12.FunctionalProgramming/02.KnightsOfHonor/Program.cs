namespace _02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printArray = arr => Console.WriteLine(string.Join("\n", arr));
            string[] input = Console.ReadLine().Split(" ").Select(x => $"Sir {x}").ToArray();
            printArray(input);
        }
    }
}
