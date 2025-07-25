using FootballManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FootballManager.Models
{
    internal class Team : ITeam
    {
        public Team(string name)
        {
            Name = name;
            ResetPoints();
            TeamManager = null;
        }

        private string name;
        private int championshipPoints;
        private IManager? teamManager;
        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.TeamNameNull);
                }
                name = value;
            }
        }

        public int ChampionshipPoints { get => championshipPoints; private set => championshipPoints = value; }

        public IManager? TeamManager { get => teamManager; private set => teamManager = value; }

        public int PresentCondition
        {
            get
            {
                if (TeamManager == null)
                {
                    return 0;
                }
                if (ChampionshipPoints == 0)
                {
                    return (int)TeamManager.Ranking;
                }
                return (int)(ChampionshipPoints * TeamManager.Ranking);
            }
        }

        public void GainPoints(int points)
        {
            ChampionshipPoints += points;
        }

        public void ResetPoints()
        {
            ChampionshipPoints = 0;
        }

        public void SignWith(IManager? manager)
        {
            teamManager = manager;
        }

        public override string ToString()
        {
            return $"Team: {Name} Points: {ChampionshipPoints}";
        }
    }
}
