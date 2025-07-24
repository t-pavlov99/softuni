using System;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 "Mitko",
                 34
             );

            bool isvalidentity = Validator.IsValid(person);

            Console.WriteLine(isvalidentity);
        }
    }
}
