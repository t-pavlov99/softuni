namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            Queue<int> orders = new(Console.ReadLine().Split(" ").Select(int.Parse));
            Console.WriteLine(orders.Max());
            while (orders.Count != 0)
            {
                if (orders.Peek() > foodQuantity)
                {
                    Console.WriteLine("Orders left: " + string.Join(" ", orders));
                    return;
                }
                foodQuantity -= orders.Dequeue();
            }
            Console.WriteLine("Orders complete");
        }
    }
}
