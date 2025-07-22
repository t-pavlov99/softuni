using System.Threading.Channels;
/*
Peter=11;George=4
Bread=10;Milk=2;
Peter Bread
George Milk
George Milk
Peter Milk
END
 */
namespace _03.ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Dictionary<string, Person> people = new();
                Dictionary<string, Product> products = new();
                string[] ppl = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                foreach (string person in ppl)
                {
                    string[] info = person.Split('=');
                    people.Add(info[0], new Person(info[0], decimal.Parse(info[1])));
                }
                string[] prd = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                foreach (string product in prd)
                {
                    string[] info = product.Split('=');
                    products.Add(info[0], new Product(info[0], decimal.Parse(info[1])));
                }
                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] parts = input.Split(" ");
                    people[parts[0]].AddProduct(products[parts[1]]);
                }
                foreach (var person in people)
                {
                    Console.Write(person.Key + " - ");
                    if (person.Value.Products.Count > 0)
                        Console.WriteLine(string.Join(", ", person.Value.Products.Select(x => x.Name)));
                    else
                        Console.WriteLine("Nothing bought");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
