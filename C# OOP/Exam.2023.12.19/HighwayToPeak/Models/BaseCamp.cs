using HighwayToPeak.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    internal class BaseCamp : IBaseCamp
    {
        public BaseCamp()
        {
            _residents = new List<string>();
        }

        private List<string> _residents;
        public IReadOnlyCollection<string> Residents => _residents.AsReadOnly();

        public void ArriveAtCamp(string climberName)
        {
            _residents.Add(climberName);
            _residents.Sort();
        }

        public void LeaveCamp(string climberName)
        {
            _residents.Remove(climberName);
        }
    }
}
