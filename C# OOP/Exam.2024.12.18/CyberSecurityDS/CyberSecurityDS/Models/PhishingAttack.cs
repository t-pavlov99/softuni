using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Models
{
    internal class PhishingAttack : CyberAttack
    {
        public PhishingAttack(string attackName, int severityLevel, string targetMail) : base(attackName, severityLevel)
        {
            TargetMail = targetMail;
        }

        private string _targetMail;

        public string TargetMail
        {
            get { return _targetMail; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Target mail is required.");
                _targetMail = value;
            }
        }

        public override string ToString()
        {
            return $"Attack: {AttackName}, Severity: {SeverityLevel} (Target Mail: {TargetMail})";
        }
    }
}
