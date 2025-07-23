namespace _04.BorderControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> list = new List<IIdentifiable>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] parts = input.Split(" ");
                switch(parts.Length)
                {
                    case 2: list.Add(new Robot(parts[1], parts[0])); break;
                    case 3: list.Add(new Citizen(parts[2], parts[0], int.Parse(parts[1]))); break;
                }
            
            }
            input = Console.ReadLine();
            foreach (IIdentifiable ident in list)
            {
                if (ident.Id.EndsWith(input))
                {
                    Console.WriteLine(ident.Id);
                }
            }


        }
    }
}
