using System.Diagnostics;
/*\
4
Peter 20
Petter 20
George 15
Peter 21

7
John 17
john 17
Stoqn 25
John 18
John 17
Sam 25
Sam 25
 */
namespace _06.EqualityLogic;

internal class Program
{
    static void Main(string[] args)
    {
        List<Person> list = new List<Person>();
        HashSet<Person> set = new HashSet<Person>();

        int N = int.Parse(Console.ReadLine()); 

        for (int i = 0; i < N; i++)
        {
            string[] cmd = Console.ReadLine().Split();
            Person person = new Person
            {
                Name = cmd[0],
                Age = int.Parse(cmd[1]),
            };
            set.Add(person);
            if (!list.Contains(person))
            {
                list.Add(person);
            }
        }

        Console.WriteLine(set.Count);
        Console.WriteLine(list.Count);
    }
}
