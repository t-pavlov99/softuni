namespace DefiningClasses;

internal class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string[] info = Console.ReadLine().Split();
            people.Add(new Person(info[0], int.Parse(info[1])));
        }
        people = people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
        people.ForEach(x => Console.WriteLine($"{x.Name} - {x.Age}"));
    }
}
