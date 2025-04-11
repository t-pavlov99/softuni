namespace _05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] isle = new char[size[0], size[1]];
            Queue<char> snake = new(Console.ReadLine());
            for (int i = 0; i < size[0]; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < size[1]; j++)
                    {
                        isle[i, j] = snake.Peek();
                        snake.Enqueue(snake.Dequeue());
                    }
                }
                else
                {
                    for (int j = size[1] - 1; j >= 0; j--)
                    {
                        isle[i, j] = snake.Peek();
                        snake.Enqueue(snake.Dequeue());
                    }
                }
            }
            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {

                    Console.Write($"{isle[i, j]}");
                }

                Console.WriteLine();
            }
        }
    }
}
