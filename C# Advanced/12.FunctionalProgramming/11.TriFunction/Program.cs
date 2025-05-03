namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            
            string[] names = Console.ReadLine().Split();
            Func<string, int, bool> Valid = (x, y) => SumOfChars(x) >= y;
            string successful = names.First(x => Valid(x, N));
            Console.WriteLine(successful);

        }

        static int SumOfChars(string a)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += (int) a[i];
            }
            return sum;
        }
    }
}
