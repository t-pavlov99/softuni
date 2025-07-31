using CyberSecurityDS.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Models
{
    internal abstract class DefensiveSoftware : IDefensiveSoftware
    {
        public DefensiveSoftware(string name, int effectiveness)
        {
            Name = name;
            Effectiveness = effectiveness;
            _assignedAttacks = new List<string>();
        }
        private string _name;
        private int _effectiveness;
        private List<string> _assignedAttacks;
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Software name is required.");
                _name = value;
            }
        }

        public int Effectiveness
        {
            get => _effectiveness;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Effectiveness cannot assign negative values.");
                }
                if (value == 0)
                {
                    _effectiveness = 1;
                }
                else
                {
                    _effectiveness = Math.Min(10, value);
                }
            }
        }

        public IReadOnlyCollection<string> AssignedAttacks => _assignedAttacks.AsReadOnly();

        public void AssignAttack(string attackName)
        {
            _assignedAttacks.Add(attackName);
        }

        public override string ToString()
        {
            string names = _assignedAttacks.Count == 0 ? "[None]" : string.Join(", ", _assignedAttacks);
            return $"Defensive Software: {Name}, Effectiveness: {Effectiveness}, Assigned Attacks: {names}";
        }
    }

}
