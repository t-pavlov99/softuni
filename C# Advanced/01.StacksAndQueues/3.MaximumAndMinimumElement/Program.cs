namespace _3.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new();
            for (int i = 0; i < n; i++)
            {
                string[] query = Console.ReadLine().Split(" ").ToArray();
                switch (query[0])
                {
                    case "1":
                        stack.Push(int.Parse(query[1]));
                        break;
                    case "2":
                        stack.Pop();
                        break;
                    case "3":
                        if (stack.Count == 0)
                            continue;
                        Console.WriteLine(stack.Max());
                        break;
                    case "4":
                        if (stack.Count == 0)
                            continue;
                        Console.WriteLine(stack.Min());
                        break;
                    default: break;
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
