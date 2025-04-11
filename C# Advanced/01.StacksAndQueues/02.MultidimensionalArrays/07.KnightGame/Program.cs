/*
8
0K0KKK00
0K00KKKK
00K0000K
KKKKKK0K
K0K0000K
KK00000K
00K0K000
000K00KK*/
namespace _07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] board = new string[size];
            for (int i = 0; i < size; i++)
            {
                board[i] = Console.ReadLine();
            }
            Console.WriteLine(MinimumKnights(board));
        }

        static int MinimumKnights(string[] board)
        {
            Dictionary<(int, int), int> attackedKnights = new();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    int count = Attacked(board, i, j);
                    if (count != 0)
                        attackedKnights.Add((i, j), count);
                }
            }
            int removed = 0;
            while (attackedKnights.Select(x => x.Value).Where(x => x != 0).Count() != 0)
            {
                (int, int) maximalKnight = attackedKnights.MaxBy(x => x.Value).Key;
                foreach ((int, int) coord in KnightMoves(maximalKnight))
                {
                    try
                    {
                        attackedKnights[coord]--;
                    }
                    catch { }
                }
                removed++;

                attackedKnights.Remove(maximalKnight);
            }
            return removed;
        }

        static List<(int, int)> KnightMoves((int, int) coord)
        {
            int a = coord.Item1;
            int b = coord.Item2;
            List<(int, int)> coords = new();
            coords.Add((a + 2, b + 1));
            coords.Add((a + 2, b - 1));
            coords.Add((a - 2, b + 1));
            coords.Add((a - 2, b - 1));
            coords.Add((a + 1, b + 2));
            coords.Add((a + 1, b - 2));
            coords.Add((a - 1, b + 2));
            coords.Add((a - 1, b - 2));
            return coords;
        }

        static int RecursiveMinimumKnights(string[] board)
        {
            if (!Attacked(board))
                return 0;
            int min = board.Length * board.Length;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[i][j] == 'K')
                    {
                        board[i] = board[i].Substring(0, j) + "0" + board[i].Substring(j + 1);
                        min = Math.Min(min, RecursiveMinimumKnights(board) + 1);
                        board[i] = board[i].Substring(0, j) + "K" + board[i].Substring(j + 1);
                    }
                }
            }

            return min;
        }

        static bool Attacked(string[] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (Attacked(board, i, j) > 0)
                        return true;
                }
            }
            return false;
        }
        static int Attacked(string[] board, int row, int col)
        {

            if (board[row][col] == '0')
                return 0;
            int count = 0;
            List<(int, int)> coords = KnightMoves((row, col));
            foreach ((int, int) coord in coords)
            {
                try
                {
                    if (board[coord.Item1][coord.Item2] == 'K')
                        count++;
                }
                catch { }
            }
            return count;

        }
    }
}
