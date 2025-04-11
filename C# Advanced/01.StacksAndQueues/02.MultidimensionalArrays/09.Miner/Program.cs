using System.Runtime.InteropServices;
/*
5
up right right up right
* * * c *
* * * e *
* * c * *
s * * c *
* * c * *
*/
namespace _09.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] cmds = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[n, n];

            int currentI = 0, currentJ = 0;
            int coal = 0;

            for (int i = 0; i < n; i++)
            {
                string[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; j++)
                {
                    field[i, j] = row[j][0];
                    if (field[i, j] == 's')
                    {
                        currentI = i;
                        currentJ = j;
                    }
                    if (field[i, j] == 'c')
                    {
                        coal++;
                    }
                }
            }

            foreach (string cmd in cmds)
            {
                int right = 0;
                int up = 0;
                switch (cmd)
                {
                    case "right": up = 1; break;
                    case "left": up = -1; break;
                    case "up": right = -1; break;
                    case "down": right = 1; break;
                }
                try
                {
                    if (field[currentI + right, currentJ + up] == 'c')
                    {
                        coal--;
                        
                        field[currentI + right, currentJ + up] = '*';
                        if (coal == 0)
                        {
                            Console.WriteLine($"You collected all coals! ({currentI + right}, {currentJ + up})");
                            return;
                        }
                    }

                    currentI += right;
                    currentJ += up;
                    if (field[currentI, currentJ] == 'e')
                    {
                        Console.WriteLine($"Game over! ({currentI}, {currentJ})");
                        return;
                    }
                }
                catch { }
            }

            Console.WriteLine($"{coal} coals left. ({currentI}, {currentJ})");


        }

        static char[,] ReadArrayFromConsole(int m, int n)
        {
            char[,] matrix = new char[m, n];
            for (int i = 0; i < m; i++)
            {
                string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
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
