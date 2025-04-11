/*
10
5
Mercedes
green
Mercedes
BMW
Skoda
green
END

9
3
Mercedes
Hummer
green
Hummer
Mercedes
green
END
 */

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int green = int.Parse(Console.ReadLine());
            int free = int.Parse(Console.ReadLine());
            int carCount = 0;
            Queue<string> cars = new();
            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                if (cmd != "green")
                {
                    cars.Enqueue(cmd);
                    continue;
                }
                int counter = 0;
                while (counter < green && cars.Count != 0)
                {
                    int carLength = cars.Peek().Length;
                    if (carLength <= green + free - counter)
                    {
                        counter += carLength;
                        cars.Dequeue();
                        carCount++;
                    }
                    else
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine(cars.Peek() + " was hit at {0}.", cars.Peek()[green+free-counter]);
                        return;
                    }
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine("{0} total cars passed the crossroads.", carCount);
        }
    }
}
