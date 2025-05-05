namespace _03.GenericSwapMethodStrings
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
            string[] indices = Console.ReadLine().Split();
            int first = int.Parse(indices[0]);
            int second = int.Parse(indices[1]);
            Box<Box<string>>.Swap(strings, first, second);
            foreach (Box<string> box in strings)
            {
                Console.WriteLine(box.ToString());
            }

        }
        public class Box<T>
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

            public static void Swap(List<T> list, int first, int second)
            {
                T temp = list[first];
                list[first] = list[second];
                list[second] = temp;
            }
        }
        
    }
}
