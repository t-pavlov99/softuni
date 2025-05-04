/*
Sam Blastoise Water 18
Narry Pikachu Electricity 22
John Kadabra Psychic 90
Tournament
Fire
Electricity
Fire
End
 */
namespace _09.PokemonTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new();
            string cmd;
            string[] info;
            while ((cmd = Console.ReadLine()) != "Tournament")
            {
                info = cmd.Split();
                int index = trainers.FindIndex(x => x.Name == info[0]);
                if (index == -1)
                {
                    trainers.Add(new Trainer { Name = info[0] });
                    index = trainers.Count - 1;
                }
                trainers[index].Pokemons.Add(
                    new Pokemon
                    {
                        Name = info[1],
                        Element = info[2],
                        Health = int.Parse(info[3])
                    });

            }
            while ((cmd = Console.ReadLine()) != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    bool foundPokemon = trainer.Pokemons.Any(x => x.Element == cmd);
                    if (foundPokemon)
                    {
                        trainer.BadgeCount++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(x => x.Health -= 10);
                        trainer.Pokemons = trainer.Pokemons.Where(x => x.Health > 0).ToList();
                    }
                }
            }

            foreach (Trainer trainer in trainers.OrderByDescending(x => x.BadgeCount))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgeCount} {trainer.Pokemons.Count}");
            }
        }
    }
}
