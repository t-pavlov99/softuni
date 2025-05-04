namespace DefiningClasses;

internal class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        Dictionary<string, Car> cars = new();
        for (int i = 0; i < N; i++)
        {
            string[] info = Console.ReadLine().Split();
            double fuelAmount = double.Parse(info[1]);
            double consumption = double.Parse(info[2]);
            cars.Add(info[0], new Car(info[0], fuelAmount, consumption));
        }

        string cmd;
        while ((cmd = Console.ReadLine()) != "End")
        {
            string[] info = cmd.Split();
            cars[info[1]].Drive(double.Parse(info[2]));
        }

        foreach (Car car in cars.Values)
        {
            Console.WriteLine(car);
        }
    }
}
