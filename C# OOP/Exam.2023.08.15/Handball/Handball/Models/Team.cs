using Handball.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    internal class Team : ITeam
    {
        public Team(string name)
        {
            Name = name;
            _pointsEarned = 0;
            _players = new List<IPlayer>();
        }

        private string _name;
        private int _pointsEarned;
        private List<IPlayer> _players;
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Team name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public int PointsEarned => _pointsEarned;

        public double OverallRating
        {
            get
            {
                return Math.Round(_players.Count == 0 ? 0 : _players.Average(x => x.Rating), 2, MidpointRounding.AwayFromZero);
            }
        }

        public IReadOnlyCollection<IPlayer> Players => _players.AsReadOnly();

        public void Draw()
        {
            _pointsEarned++;
            _players.FirstOrDefault(x => x.GetType() == typeof(Goalkeeper))?.IncreaseRating();
        }

        public void Lose()
        {
            _players.ForEach(x => x.DecreaseRating());
        }

        public void SignContract(IPlayer player)
        {
            _players.Add(player);
        }

        public void Win()
        {

            _pointsEarned += 3;
            _players.ForEach(x => x.IncreaseRating());
        }

        public override string ToString()
        {
            string names = _players.Count == 0 ? "none" : string.Join(", ", _players.Select(x => x.Name));
            return $"Team: {Name} Points: {PointsEarned}\n--Overall rating: {OverallRating}\n--Players: {names}";
        }
    }
}
