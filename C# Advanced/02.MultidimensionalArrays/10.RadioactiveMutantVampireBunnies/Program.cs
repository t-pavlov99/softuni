using System;
using System.Threading.Tasks.Dataflow;
/*
5 8
.......B
...B....
....B..B
........
..P.....
ULLL

4 5
.....
.....
.B...
...P.
LLLLLLLL
*/

namespace _10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> size = Console.ReadLine().Split().ToList();
            int n = int.Parse(size[0]);
            int m = int.Parse(size[1]);
            char[,] lair = new char[n, m];

            //player position
            int x = 0, y = 0;

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    lair[i, j] = line[j];
                    if (lair[i, j] == 'P')
                    {
                        lair[i, j] = '.';
                        x = i;
                        y = j;
                    }
                }
            }

            bool won = false;
            bool lost = false;


            int down = 0, right = 0;

            string cmds = Console.ReadLine();
            foreach (char c in cmds)
            {

                switch (c)
                {
                    case 'L':
                        down = 0;
                        right = -1;
                        break;
                    case 'U':
                        down = -1;
                        right = 0;
                        break;
                    case 'D':
                        down = 1;
                        right = 0;
                        break;
                    case 'R':
                        down = 0;
                        right = 1;
                        break;
                    default: break;
                }

                try
                {
                    if (lair[x + down, y + right] == 'B')
                    {
                        x += down;
                        y += right;
                        lost = true;
                    }
                    else
                    {
                        lair[x, y] = '.';
                        x += down;
                        y += right;
                        lair[x, y] = 'P';
                    }
                }
                catch
                {
                    lair[x, y] = '.';

                    x += down;
                    y += right;
                    won = true;
                }

                List<(int, int)> coords = new();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (lair[i, j] == 'B')
                        {
                            coords.Add((i, j));
                        }
                    }
                }
                foreach ((int, int) coord in coords)
                {
                    try
                    {
                        lair[coord.Item1 + 1, coord.Item2] = 'B';
                        if (x == coord.Item1 + 1 && y == coord.Item2)
                        {
                            lost = true;
                        }
                    }
                    catch { }

                    try
                    {
                        lair[coord.Item1, coord.Item2 + 1] = 'B';
                        if (x == coord.Item1 && y == coord.Item2 + 1)
                        {
                            lost = true;
                        }
                    }
                    catch { }

                    try
                    {
                        lair[coord.Item1, coord.Item2 - 1] = 'B';
                        if (x == coord.Item1 && y == coord.Item2 - 1)
                        {
                            lost = true;
                        }
                    }
                    catch { }

                    try
                    {
                        lair[coord.Item1 - 1, coord.Item2] = 'B';
                        if (x == coord.Item1 - 1 && y == coord.Item2)
                        {
                            lost = true;
                        }
                    }
                    catch { }
                    //Console.WriteLine($"x = {coord.Item1}, y = {coord.Item2}"); PrintCharArray(lair, n, m);
                }
                if (won || lost)
                    break;
            }

            if (won)
            {

                PrintCharArray(lair, n, m);
                Console.WriteLine($"won: {x - down} {y - right}");
            }
            else if (lost)
            {
                PrintCharArray(lair, n, m);
                Console.WriteLine($"dead: {x} {y}");
                return;
            }
        }

        static void PrintStringArray(string[] arr)
        {
            foreach (string c in arr)
                Console.WriteLine(c);
        }

        static void PrintCharArray(char[,] arr, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
        }


    }
}
