namespace _03.Telephony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();
            List<Phone> phones = new();
            List<Website> websites = new();
            foreach (string s in numbers)
            {
                if (s.Length == 7)
                {
                    phones.Add(new StationaryPhone(s));
                }
                if (s.Length == 10)
                {
                    phones.Add(new SmartPhone(s));
                }
            }
            phones.ForEach(phone => Console.WriteLine(phone.Call()));
            foreach (string s in urls)
            {
                websites.Add(new Website(s));
            }
            websites.ForEach(website => Console.WriteLine(website.Browse()));
        }
    }
}
