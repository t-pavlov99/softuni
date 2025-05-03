using System;

namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> printer = s => Console.WriteLine(string.Join("\n", s.Split(" ")));

            printer(Console.ReadLine());
        }
    }
}