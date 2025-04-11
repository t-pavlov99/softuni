namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> values = new(Console.ReadLine().Split(" ").Select(int.Parse));
            int capacity = int.Parse(Console.ReadLine());
            int sum = capacity;
            int racks = 0;
            while (values.Count != 0)
            {
                if (sum + values.Peek() > capacity)
                {
                    racks++;
                    sum = values.Pop();
                }
                else
                {
                    sum += values.Pop();
                }
            }
            Console.WriteLine(racks);
        }
    }
}
