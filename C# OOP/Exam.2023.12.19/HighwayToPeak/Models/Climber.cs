using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        public Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            _conqueredPeaks = new List<string>();
        }

        private string _name;
        private int _stamina;
        private List<string> _conqueredPeaks;
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PeakNameNullOrWhiteSpace);
                }
                _name = value;
            }
        }

        public int Stamina
        {
            get => _stamina;
            protected set
            {
                _stamina = Math.Min(10, Math.Max(0, value));
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks
        {
            get => _conqueredPeaks.AsReadOnly();
        }

        public void Climb(IPeak peak)
        {
            if (!_conqueredPeaks.Contains(peak.Name))
            {
                _conqueredPeaks.Add(peak.Name);
            }
            switch (peak.DifficultyLevel)
            {
                case "Extreme": Stamina -= 6; break;
                case "Hard": Stamina -= 4; break;
                case "Moderate": Stamina -= 2; break;
                default: break;
            }
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            return $"{GetType().Name} - Name: {Name}, Stamina: {Stamina}" + "\n" +
                     $"Peaks conquered: " +
                     ((_conqueredPeaks.Count == 0) ? "no peaks conquered" :  $"{_conqueredPeaks.Count}");
        }
    }
}
