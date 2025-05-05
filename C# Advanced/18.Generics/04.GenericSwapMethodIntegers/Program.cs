namespace _04.GenericSwapMethodIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<Box<int>> ints = new List<Box<int>>();
            for (int i = 0; i < N; i++)
            {
                ints.Add(new Box<int>(int.Parse(Console.ReadLine())));
            }
            string[] indices = Console.ReadLine().Split();
            int first = int.Parse(indices[0]);
            int second = int.Parse(indices[1]);
            Box<Box<int>>.Swap(ints, first, second);
            foreach (Box<int> box in ints)
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
