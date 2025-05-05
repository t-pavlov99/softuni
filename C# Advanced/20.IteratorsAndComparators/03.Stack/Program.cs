/*
Push 1, 2, 3, 4
Pop
Pop
Pop
Pop
Pop
END
 */
namespace _03.Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> ints = new CustomStack<int>();

            string cmd;

            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] parts = cmd.Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                switch (parts[0])
                {
                    case "Push":
                        foreach (string number in parts.Skip(1))
                        {
                            ints.Push(int.Parse(number));
                        }
                        break;
                    case "Pop":
                        try
                        {
                            ints.Pop();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    default:
                        break;
                }
                
            }
            foreach (int number in ints)
            {
                Console.WriteLine(number);
            }

            foreach (int number in ints)
            {
                Console.WriteLine(number);
            }
        }
    }
}
