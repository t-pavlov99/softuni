using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    internal class Peak : IPeak
    {
        public Peak(string name, int elevation, string difficultyLevel)
        { 
            Name = name;
            Elevation = elevation;
            DifficultyLevel = difficultyLevel;
        }

        private string _name;
        private int _elevation;
        private string _difficulty;
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

        public int Elevation
        {
            get => _elevation;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.PeakElevationNegative);
                }
                _elevation = value;
            }
        }

        public string DifficultyLevel
        {
            get => _difficulty;
            private set => _difficulty = value;
        }

        public override string ToString()
        {
            return $"Peak: {Name} -> Elevation: {Elevation}, Difficulty: {DifficultyLevel}";
        }
    }
}
