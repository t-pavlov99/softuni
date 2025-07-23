namespace _02.VehiclesExtension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string[] parts = Console.ReadLine().Split();

                Vehicle vehicle = car;
                switch (parts[1])
                {
                    case "Truck": vehicle = truck; break;
                    case "Bus": vehicle = bus; break;
                }
                double info = double.Parse(parts[2]);
                switch (parts[0])
                {
                    case "DriveEmpty":
                        if (bus.Drive(false, info))
                        {
                            Console.WriteLine($"{bus.GetType().Name} travelled {info} km");
                        }
                        else
                        {
                            Console.WriteLine($"{bus.GetType().Name} needs refueling");
                        }
                        break;
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
                        try
                        {
                            if (!vehicle.Refuel(info))
                            {
                                Console.WriteLine("Fuel must be a positive number");
                            }
                        } 
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
