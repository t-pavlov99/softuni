using System.Linq.Expressions;

namespace _07.Tuple;

internal class Program
{
    static void Main(string[] args)
    {
        string[] nameAndAdress = Console.ReadLine().Split();
        CustomTuple<string, string> tuple1 =
            new CustomTuple<string, string>
            (nameAndAdress[0] + ' ' + nameAndAdress[1], nameAndAdress[2]);
        string[] nameAndBeer = Console.ReadLine().Split();
        CustomTuple<string, double> tuple2 =
            new CustomTuple<string, double>
            (nameAndBeer[0], double.Parse(nameAndBeer[1]));
        string[] twoNumbers = Console.ReadLine().Split();
        CustomTuple<int, double> tuple3 =
            new CustomTuple<int, double>
            (int.Parse(twoNumbers[0]), double.Parse(twoNumbers[1]));
        Console.WriteLine(tuple1);
        Console.WriteLine(tuple2);
        Console.WriteLine(tuple3);

    }
}
