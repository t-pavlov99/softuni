using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    internal abstract class Diver : IDiver
    {
        protected Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            _catch = new List<string>();
            CompetitionPoints = 0;
            HasHealthIssues = false;
        }

        private string _name;
        private int _oxygenLevel;
        private List<string> _catch;
        private double _competitionPoints;
        private bool _hasHealthIssues;
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }
                _name = value;
            }
        }

        public int OxygenLevel
        {
            get => _oxygenLevel;
            protected set
            {
                _oxygenLevel = Math.Max(value, 0);
                if (_oxygenLevel == 0)
                {
                    HasHealthIssues = true;
                }
            }
        }

        public IReadOnlyCollection<string> Catch => _catch.AsReadOnly();

        public double CompetitionPoints
        {
            get => Math.Round(_competitionPoints, 1);
            private set => _competitionPoints = value;
        }

        public bool HasHealthIssues { get => _hasHealthIssues; private set => _hasHealthIssues = value; }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            _catch.Add(fish.Name);
            CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            HasHealthIssues = !HasHealthIssues;
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
