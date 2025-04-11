/*
4 5
1 5 5 2 4
2 1 4 14 3
3 7 11 2 8
4 8 12 16 4
*/
namespace _03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] matrix = ReadArrayFromConsole(size[0], size[1]);
            if (size[0] < 3 || size[1] < 3)
                return;
            int maxI = 0, maxJ = 0, maxSum = int.MinValue;
            for (int i = 0; i < size[0] - 2; i++)
            {
                for (int j = 0; j < size[1] - 2; j++)
                {
                    int currentSum =
                          matrix[i, j]     + matrix[i, j + 1]     + matrix[i, j + 2]
                        + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                        + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxI = i;
                        maxJ = j;
                    }

                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = maxI; i <= maxI + 2; i++)
            {
                for (int j = maxJ; j <= maxJ + 2; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
        }

        static int[,] ReadArrayFromConsole(int m, int n)
        {
            int[,] matrix = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
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
