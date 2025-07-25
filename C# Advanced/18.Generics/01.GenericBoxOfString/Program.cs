﻿namespace _01.GenericBoxOfString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(new Box<string>(Console.ReadLine()).ToString());
            }
        }
    }

    public class Box<T>
    {
        public T Value { get; set; }

        public Box(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.GetType().ToString() + ": " + Value.ToString();
        }
    }
}
