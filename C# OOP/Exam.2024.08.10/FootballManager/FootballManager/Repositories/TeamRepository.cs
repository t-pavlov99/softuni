using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballManager.Repositories.Contracts;
using FootballManager.Utilities.Messages;
using FootballManager.Models.Contracts;

namespace FootballManager.Repositories
{
    internal class TeamRepository : IRepository<ITeam>
    {

        public TeamRepository()
        {
            teams = new List<ITeam>();
        }
        private List<ITeam> teams;
        public IReadOnlyCollection<ITeam> Models { get => teams.AsReadOnly(); }

        public int Capacity { get => 10; }



        public void Add(ITeam model)
        {
            if (teams.Count == Capacity)
            {
                return;
            }
            teams.Add(model);
        }

        public bool Exists(string name)
        {
            return Get(name) != null;
        }

        public ITeam? Get(string name)
        {
            return teams.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(string name)
        {
            ITeam team = Get(name);
            if (team == null)
                return false;
            return teams.Remove(team);
        }
    }
}
