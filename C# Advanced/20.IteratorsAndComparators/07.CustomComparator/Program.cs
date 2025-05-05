namespace _07.CustomComparator;

internal class Program
{
    static void Main(string[] args)
    {
        int[] ints = Console.ReadLine().Split().Select(int.Parse).ToArray();
        IComparer<int> comparer = Comparer<int>.Create(Compare);
        Array.Sort(ints, comparer);
        Console.WriteLine(string.Join(" ", ints));
    }

    public static int Compare(int x, int y)
    {
        if (x % 2 == 0 && y % 2 != 0)
            return -1;
        if (x % 2 != 0 && y % 2 == 0)
            return 1;
        return x - y;
    }
}
