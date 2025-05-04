using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses;

public class StartUp
{
    public static void Main(string[] args)
    {
        Family family = new Family();
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string[] info = Console.ReadLine().Split(' ');

            family.AddMember(new Person(info[0], int.Parse(info[1])));
        }
        Console.WriteLine(family.GetOldestMember());
    }
}