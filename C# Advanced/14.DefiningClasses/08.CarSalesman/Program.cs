using System;
using System.Reflection;
using System.Text;
/*
2
V8-101 220 50
V4-33 140 28 B
3
FordFocus V4-33 1300 Silver
FordMustang V8-101
VolkswagenGolf V4-33 Orange */
namespace _08.CarSalesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>(N);
            for (int i = 0; i < N; i++)
            {
                string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = parts[0];
                int power = int.Parse(parts[1]);
                int? displacement = null;
                string? efficiency = null;

                if (parts.Length == 4)
                {
                    displacement = int.Parse(parts[2]);
                    efficiency = parts[3];
                }

                if (parts.Length == 3)
                {
                    try
                    {
                        displacement = int.Parse(parts[2]);
                    }
                    catch
                    {
                        efficiency = parts[2];
                    }
                }

                engines.Add(model, new Engine
                {
                    Model = model,
                    Displacement = displacement,
                    Efficiency = efficiency,
                    Power = power
                });
            }

            int M = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>(M);
            for (int i = 0; i < M; i++)
            {
                List<string> parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                string model = parts[0];
                string engine = parts[1];
                int? weight = null;
                string? color = null;

                if (parts.Count == 4)
                {
                    weight = int.Parse(parts[2]);
                    color = parts[3];
                }

                if (parts.Count == 3)
                {
                    if (int.TryParse(parts[2], out int w))
                    {
                        weight = w;
                    }
                    else
                    {
                        color = parts[2];
                    }
                }

                cars.Add(new Car
                {
                    Model = model,
                    Engine = engines[engine],
                    Weight = weight,
                    Color = color
                });
            }

            cars.ForEach(Console.WriteLine);
        }
    }
}
