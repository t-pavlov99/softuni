namespace _01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                    matrix[i, j] = numbers[j];
            }
            int primarySum = 0, secondarySum = 0;
            for (int i = 0; i < n; i++)
            {
                primarySum += matrix[i, i];
                secondarySum += matrix[i, n - i - 1];
            }
            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }

        static int[,] ReadArrayFromConsole(int m, int n)
        {
            int[,] matrix = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                    matrix[i, j] = numbers[j];
            }
            return matrix;
        }

        static int[,] ReadArrayFromConsole(int n)
        {
            return ReadArrayFromConsole(n, n);
        }
    }
}
