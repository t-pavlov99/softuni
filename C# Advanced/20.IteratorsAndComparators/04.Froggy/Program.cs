namespace _04.Froggy;

internal class Program
{
    static void Main(string[] args)
    {
        Lake lake = new Lake(Console.ReadLine());
        Console.WriteLine(string.Join(", ", lake));
    }
}
