namespace _02.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = ReadArrayFromConsole(size[0], size[1]);
            int count = 0;
            for (int i = 0; i < size[0] - 1; i++)
            {
                for (int j = 0; j < size[1] - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 1, j + 1])
                        count++;
                }
            }
            Console.WriteLine(count);
        }

        static char[,] ReadArrayFromConsole(int m, int n)
        {
            char[,] matrix = new char[m, n];
            for (int i = 0; i < m; i++)
            {
                string[] numbers = Console.ReadLine().Split().ToArray();
                for (int j = 0; j < n; j++)
                    matrix[i, j] = numbers[j][0];
            }
            return matrix;
        }

        static char[,] ReadArrayFromConsole(int n)
        {
            return ReadArrayFromConsole(n, n);
        }
    }
}
