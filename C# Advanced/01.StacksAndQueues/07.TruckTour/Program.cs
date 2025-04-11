namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<Pump> pumps = new();
            for (int i = 0; i < n; i++)
            {
                int[] info = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                pumps.Enqueue(new Pump(info[0], info[1]));
            }
            int fuel = 0;
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                Pump first = pumps.Dequeue();
                if (fuel + first.Petrol < first.Distance)
                {
                    fuel = 0;
                    index = i + 1;
                    continue;
                }
                fuel += first.Petrol - first.Distance;
            }
            Console.WriteLine(index);
        }
    }

    class Pump
    {
        public Pump(int petrol, int distance)
        {
            Petrol = petrol;
            Distance = distance;
        }
        public int Petrol { set; get; }
        public int Distance { get; set; }
    }
}
