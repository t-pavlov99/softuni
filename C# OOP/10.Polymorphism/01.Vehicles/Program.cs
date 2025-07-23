namespace _01.Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string[] parts = Console.ReadLine().Split();

                Vehicle vehicle = parts[1] == "Car" ? car : truck;
                double info = double.Parse(parts[2]);
                switch (parts[0])
                {
                    case "Drive":
                        if (vehicle.Drive(info))
                        {
                            Console.WriteLine($"{vehicle.GetType().Name} travelled {info} km");
                        }
                        else
                        {
                            Console.WriteLine($"{vehicle.GetType().Name} needs refueling");
                        }
                        break;
                    case "Refuel":
                        vehicle.Refuel(info);
                        break;
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);

        }
    }
}
