using CyberSecurityDS.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Models
{
    internal abstract class CyberAttack : ICyberAttack
    {
        public CyberAttack(string attackName, int severityLevel)
        {
            AttackName = attackName;
            SeverityLevel = severityLevel;
            Status = false;
        }

        private string _attackName;
        private int _securityLevel;
        private bool _status;
        public string AttackName
        {
            get { return _attackName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Attack name is required.");
                _attackName = value;
            }
        }
        public int SeverityLevel
        {
            get { return _securityLevel; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Severity level cannot assign negative values.");
                }
                if (value == 0)
                {
                    _securityLevel = 1;
                }
                else
                {
                    _securityLevel = Math.Min(10, value);
                }
            }
        }

        public bool Status
        {
            get { return _status; }
            private set { _status = value; }
        }

        public void MarkAsMitigated()
        {
            Status = true;
        }
    }
}
