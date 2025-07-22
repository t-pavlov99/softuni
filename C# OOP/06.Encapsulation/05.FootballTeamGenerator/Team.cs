using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FootballTeamGenerator
{
    internal class Team
    {
        private string name;
        private Dictionary<string, Player> players;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                    throw new Exception("A name should not be empty.");
                name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player.Name, player);
        }

        public void RemovePlayer(string player)
        {
            if (!players.Remove(player))
                throw new Exception($"Player {player} is not in {Name} team.");
        }

        public decimal Rating
        {
            get => Math.Round(players.Select(x => x.Value.Skill).DefaultIfEmpty().Average());
        }

        public Team(string name)
        {
            Name = name;
            players = new Dictionary<string, Player>();
        }
    }
}