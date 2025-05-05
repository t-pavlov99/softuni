using Microsoft.VisualBasic;

namespace _05.GenericCountMethodStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<Box<string>> strings = new List<Box<string>>();
            for (int i = 0; i < N; i++)
            {
                strings.Add(new Box<string>(Console.ReadLine()));
            }
            string value = Console.ReadLine();
            Console.WriteLine(Box<string>.Count(strings, value));
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
            public static int Count<T>(List<Box<T>> list, T value) where T: IComparable
            {
                return list.Where(x => x.CompareTo(new Box<T>(value)) > 0).Count();
            }
        }
    }
}
