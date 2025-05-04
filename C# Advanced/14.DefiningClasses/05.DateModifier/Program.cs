using DefiningClasses;
namespace _05.DateModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Date date1 = new Date(Console.ReadLine());
            Date date2 = new Date(Console.ReadLine());
            if (date2.EarlierThan(date1))
            {
                Date copy = date1;
                date1 = date2;
                date2 = copy;
            }
            int count = 0;
            while (!date1.Equals(date2))
            {
                date1.AddDay();
                count++;
            }
            Console.WriteLine(count);
        }
    }
}
