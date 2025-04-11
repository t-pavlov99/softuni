/*
50
2
11 10 5 11 10 20
15 13 16
1500

20
6
14 13 12 11 10 5
13 3 11 10
800

33
1
12 11 10
10 20 30
100
 */
namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int price = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new(Console.ReadLine().Split(" ").Select(int.Parse));
            Queue<int> locks = new(Console.ReadLine().Split(" ").Select(int.Parse));
            int value = int.Parse(Console.ReadLine());

            int barrelRemaining = barrelSize;
            int leftBullets = bullets.Count;
            while (bullets.Count != 0 && locks.Count != 0)
            {
                
                leftBullets--;
                barrelRemaining--;
                
                value -= price;
                if (bullets.Pop() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (barrelRemaining == 0 && bullets.Count != 0)
                {
                    barrelRemaining = barrelSize;
                    Console.WriteLine("Reloading!");
                }
            }
            if (locks.Count == 0)
                Console.WriteLine($"{leftBullets} bullets left. Earned ${value}");
            else
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}
