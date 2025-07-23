namespace _03.Raiding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            BaseHero[] list = new BaseHero[N];
            for (int i = 0; i < N; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                try
                {
                    list[i] = CreateHero(type, name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            int total = 0;
            foreach (var item in list)
            {
                total += item.Power;
                Console.WriteLine(item.CastAbility());
            }
            if (total >=  bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }

        static BaseHero CreateHero(string type, string name)
        {
            switch (type)
            {
                case "Druid": return new Druid(name);
                case "Paladin": return new Paladin(name);
                case "Rogue": return new Rogue(name);
                case "Warrior": return new Warrior(name);
                default: throw new Exception("Invalid hero!");
            }
        }
    }
}
