namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int threshold = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ").Where(x => x.Length <= threshold).ToArray();
            Console.WriteLine(string.Join("\n", names));
        }
    }
}
