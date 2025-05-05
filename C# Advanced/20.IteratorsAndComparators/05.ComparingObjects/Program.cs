namespace _05.ComparingObjects;
/*
Peter 22 Varna
George 22 Varna
George 22 Varna
END
2
    */
internal class Program
{
    static void Main(string[] args)
    {
        List<Person> list = new List<Person>();

        string cmd;

        while ((cmd = Console.ReadLine()) != "END")
        {
            string[] parts = cmd.Split();
            list.Add(new Person { Name = parts[0], Age = int.Parse(parts[1]), Town = parts[2] });
        }

        Person person = list[int.Parse(Console.ReadLine()) - 1];

        int equals = 0;
        foreach (Person p in list)
        {
            equals += (p.CompareTo(person) == 0) ? 1 : 0;
        }

        if (equals == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equals} {list.Count - equals} {list.Count}");
        }
    }
}
