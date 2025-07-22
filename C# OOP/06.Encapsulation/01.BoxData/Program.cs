using System.Net.WebSockets;

namespace _01.BoxData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                double l = double.Parse(Console.ReadLine());
                double w = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                Box b = new Box(l, w, h);
                Console.WriteLine($"Surface Area - {b.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {b.LateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {b.Volume():f2}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
