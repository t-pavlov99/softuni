namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] info = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> queue = new();
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            for (int i = 0; i < info[0]; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < info[1]; i++)
            {
                queue.Dequeue();
            }
            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            int smallest = int.MaxValue;
            do
            {
                int current = queue.Dequeue();
                if (current == info[2])
                {
                    Console.WriteLine("true");
                    return;
                }
                smallest = Math.Min(current, smallest);
            } while (queue.Count != 0);
            Console.WriteLine(smallest);
        }
    }
}
