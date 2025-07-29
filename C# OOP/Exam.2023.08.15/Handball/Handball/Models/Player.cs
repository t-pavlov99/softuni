using Handball.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    internal abstract class Player : IPlayer
    {
        public Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }

        private string _name;
        private double _rating;
        private string _team;
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Player name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public double Rating
        {
            get { return _rating; }
            protected set
            {
                _rating = Math.Max(Math.Min(value, 10), 1);
            }
        }

        public string Team => _team;

        public abstract void DecreaseRating();

        public abstract void IncreaseRating();
        public void JoinTeam(string name)
        {
            _team = name;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name}\n--Rating: {Rating}";
        }
    }
}
