using _04.BorderControl;
namespace _05.BirthdayCelebrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] parts = input.Split();
                switch (parts[0])
                {
                    case "Pet": birthables.Add(new Pet(parts[2], parts[1])); break;
                    case "Citizen": birthables.Add(new Citizen(parts[3], parts[1], int.Parse(parts[2]), parts[4])); break;
                    default: continue;
                }
            }
            input = Console.ReadLine();
            foreach (var birthable in birthables)
            {
                if (birthable.Birthdate.EndsWith(input))
                {
                    Console.WriteLine(birthable.Birthdate);
                }
            }
        }
    }
}
