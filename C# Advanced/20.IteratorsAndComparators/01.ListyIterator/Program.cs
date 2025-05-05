namespace _01.ListyIterator;

internal class Program
{
    static void Main(string[] args)
    {
        string[] elems = Console.ReadLine().Split().Skip(1).ToArray();
        ListyIterator<string> iterator = new ListyIterator<string>(elems);

        string cmd;

        while ((cmd = Console.ReadLine()) != "END")
        {
            string[] parts = cmd.Split();

            switch (parts[0])
            {
                case "Move":
                    Console.WriteLine(iterator.Move());
                    break;
                case "Print":
                    try
                    {
                        iterator.Print();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "HasNext":
                    Console.WriteLine(iterator.HasNext());
                    break;
                default:
                    break;
            }
        }
    }
}
