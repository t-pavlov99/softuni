using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string name = info[0];
                    int age = int.Parse(info[1]);

                    switch (input)
                    {
                        case "Cat": animals.Add(new Cat(name, age, info[2])); break;
                        case "Dog": animals.Add(new Dog(name, age, info[2])); break;
                        case "Frog": animals.Add(new Frog(name, age, info[2])); break;
                        case "Kitten": animals.Add(new Kitten(name, age)); break;
                        case "Tomcat": animals.Add(new Tomcat(name, age)); break;
                        default: throw new Exception();
                    }
                    Animal animal = animals.Last();
                    Console.WriteLine(input);
                    Console.WriteLine(animal.ToString());
                    animal.ProduceSound();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var animal in animals)
            {
                
            }

        }
    }
}
