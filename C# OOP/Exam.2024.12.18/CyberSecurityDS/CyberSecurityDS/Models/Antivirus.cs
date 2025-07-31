using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Models
{
    internal class Antivirus : DefensiveSoftware
    {
        public Antivirus(string name, int effectiveness) : base(name, effectiveness)
        {
        }
    }
}
