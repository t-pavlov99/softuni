using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    internal abstract class Fish : IFish
    {
        public Fish(string name, double points, int timeToCatch)
        {
            Name = name;
            Points = points;
            TimeToCatch = timeToCatch;
        }

        private string _name;
        private double _points;
        private int _timeToCatch;
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FishNameNull);
                }
                _name = value;
            }
        }

        public double Points
        {
            get => _points;
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.PointsNotInRange);
                }
                _points = value;
            }
        }

        public int TimeToCatch { get => _timeToCatch; private set => _timeToCatch = value; }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
        }
    }
}
