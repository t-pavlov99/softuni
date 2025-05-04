namespace DefiningClasses;
internal class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        Car[] cars = new Car[N];
        for (int i = 0; i < N; i++)
        {
            string[] info = Console.ReadLine().Split().ToArray();

            string model = info[0];

            int speed = int.Parse(info[1]);
            int power = int.Parse(info[2]);
            Engine engine = new Engine(speed, power);

            int weight = int.Parse(info[3]);
            string type = info[4];
            Cargo cargo = new Cargo(weight, type);

            Tyre[] tyres = new Tyre[4];
            for (int j = 0; j < 4; j++)
            {
                double pressure = double.Parse(info[5 + 2 * j]);
                int age = int.Parse(info[6 + 2 * j]);
                tyres[j] = new Tyre(age, pressure);
            }
            cars[i] = new Car(model, engine, cargo, tyres);
        }

        switch (Console.ReadLine())
        {
            case "fragile":
                foreach (Car car in cars.Where(x => x.Cargo.Type == "fragile" &&
                                                    x.Tyres.Where(x => x.Pressure < 1).Count() >= 1))
                {
                    Console.WriteLine(car.Model);
                }
                break;
            case "flammable":
                foreach (Car car in cars.Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
                break;
        }
    }
}
