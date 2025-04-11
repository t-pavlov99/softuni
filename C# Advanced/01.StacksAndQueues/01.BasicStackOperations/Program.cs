namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] info = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> stack = new();
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            for (int i = 0; i < info[0]; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int i = 0; i < info[1]; i++)
            {
                stack.Pop();
            }
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            int smallest = int.MaxValue;
            do
            {
                int current = stack.Pop();
                if (current == info[2])
                {
                    Console.WriteLine("true");
                    return;
                }
                smallest = Math.Min(current, smallest);
            } while (stack.Count != 0);
            Console.WriteLine(smallest);
        }
    }
}
