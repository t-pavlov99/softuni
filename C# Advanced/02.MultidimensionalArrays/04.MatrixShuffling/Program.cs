/*
2 3
1 2 3
4 5 6
swap 0 0 1 1
swap 10 9 8 7
swap 0 1 1 0
END
    */
namespace _04.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = ReadArrayFromConsole(size[0], size[1]);
            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] parts = cmd.Split().ToArray();
                if (parts.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if (parts[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                int row1 = int.Parse(parts[1]);
                int col1 = int.Parse(parts[2]);
                int row2 = int.Parse(parts[3]);
                int col2 = int.Parse(parts[4]);
                try
                {
                    string copy = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = copy;
                } catch
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                for (int i = 0; i < size[0]; i++)
                {
                    for (int j = 0; j < size[1]; j++)
                    {
                        Console.Write($"{matrix[i,j]} ");
                    }
                    Console.WriteLine();
                }
            }
        }

        static string[,] ReadArrayFromConsole(int m, int n)
        {
            string[,] matrix = new string[m, n];
            for (int i = 0; i < m; i++)
            {
                string[] numbers = Console.ReadLine().Split().ToArray();
                for (int j = 0; j < n; j++)
                    matrix[i, j] = numbers[j];
            }
            return matrix;
        }

        static string[,] ReadArrayFromConsole(int n)
        {
            return ReadArrayFromConsole(n, n);
        }
    }
}
