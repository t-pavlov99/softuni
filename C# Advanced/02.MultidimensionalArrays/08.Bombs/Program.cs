/*
4
8 3 2 5
6 4 7 9
9 9 3 6
6 8 1 2
1,2 2,1 2,0
*/
namespace _08.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] ints = ReadArrayFromConsole(n);
            List<(int, int)> bombs = new();
            string[] coordStrings = Console.ReadLine().Split(" ");
            foreach (string c in coordStrings)
            {
                int[] cs = c.Split(",").Select(int.Parse).ToArray();
                bombs.Add((cs[0], cs[1]));
            }
            foreach ((int, int) bomb in bombs)
            {
                if (ints[bomb.Item1, bomb.Item2] > 0)
                {
                    int value = ints[bomb.Item1, bomb.Item2];
                    for (int i = Math.Max(0, bomb.Item1 - 1); i <= Math.Min(n - 1, bomb.Item1 + 1); i++)
                    {
                        for (int j = Math.Max(0, bomb.Item2 - 1); j <= Math.Min(n - 1, bomb.Item2 + 1); j++)
                        {
                            if (ints[i, j] > 0)
                                ints[i, j] -= value;
                        }
                    }
                }
            }
            
            int sum = 0;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (ints[i, j] > 0)
                    {
                        sum += ints[i, j];
                        count++;
                    }
                }
            }
            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{ints[i, j]} ");
                }
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
