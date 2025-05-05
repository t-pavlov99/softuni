using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.GenericCountMethodDouble;

internal class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<Box<double>> doubles = new List<Box<double>>();
        for (int i = 0; i < N; i++)
        {
            doubles.Add(new Box<double>(double.Parse(Console.ReadLine())));
        }
        double value = double.Parse(Console.ReadLine());
        Console.WriteLine(Box<double>.Count(doubles, value));
    }


    public class Box<T> where T : IComparable
    {
        public T Value { get; set; }

        public Box(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.GetType().ToString() + ": " + Value.ToString();
        }
        public int CompareTo(Box<T> other)
        {
            return Value.CompareTo(other.Value);
        }
        public static int Count<T>(List<Box<T>> list, T value) where T : IComparable
        {
            return list.Where(x => x.CompareTo(new Box<T>(value)) > 0).Count();
        }
    }
}
