using CyberSecurityDS.Core.Contracts;
using CyberSecurityDS.Models;
using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Core
{
    internal class Controller : IController
    {
        public Controller()
        {
            sm = new SystemManager();
        }

        private SystemManager sm;

        private bool ValidAttack(string type)
        {
            return type == nameof(PhishingAttack) || type == nameof(MalwareAttack);
        }

        private ICyberAttack CreateAttack(string type, string name, int severityLevel, string extraInfo)
        {
            switch (type)
            {
                case nameof(PhishingAttack): return new PhishingAttack(name, severityLevel, extraInfo);
                case nameof(MalwareAttack): return new MalwareAttack(name, severityLevel, extraInfo);
                default: return null;
            }
        }

        private bool ValidSoftware(string type)
        {
            return type == nameof(Firewall) || type == nameof(Antivirus);
        }

        private IDefensiveSoftware CreateSoftware(string type, string name, int effectiveness)
        {
            switch (type)
            {
                case nameof(Firewall): return new Firewall(name, effectiveness);
                case nameof(Antivirus): return new Antivirus(name, effectiveness);
                default: return null;
            }
        }
        public string AddCyberAttack(string attackType, string attackName, int severityLevel, string extraParam)
        {
            if (!ValidAttack(attackType))
            {
                return $"{attackType} is not a valid type for the system.";
            }
            if (sm.CyberAttacks.Exists(attackName))
            {
                return $"{attackName} already exists in the system.";
            }
            sm.CyberAttacks.AddNew(CreateAttack(attackType, attackName, severityLevel, extraParam));
            return $"{attackType}: {attackName} is added to the system.";
        }

        public string AddDefensiveSoftware(string softwareType, string softwareName, int effectiveness)
        {
            if (!ValidSoftware(softwareType))
            {
                return $"{softwareType} is not a valid type for the system.";
            }
            if (sm.DefensiveSoftwares.Exists(softwareName))
            {
                return $"{softwareName} already exists in the system.";
            }
            sm.DefensiveSoftwares.AddNew(CreateSoftware(softwareType, softwareName, effectiveness));
            return $"{softwareType}: {softwareName} is added to the system.";
        }

        public string AssignDefense(string cyberAttackName, string defensiveSoftwareName)
        {
            if (!sm.CyberAttacks.Exists(cyberAttackName))
            {
                return $"{cyberAttackName} does not exist in the system.";
            }
            var ds = sm.DefensiveSoftwares.GetByName(defensiveSoftwareName);
            if (ds == null)
            {
                return $"{defensiveSoftwareName} does not exist in the system.";
            }
            var ds1 = sm.DefensiveSoftwares.Models.FirstOrDefault(x => x.AssignedAttacks.Contains(cyberAttackName));
            if (ds1 != null)
            {
                return $"{cyberAttackName} is already assigned to {ds1.Name}.";
            }
            ds.AssignAttack(cyberAttackName);
            return $"{cyberAttackName} is assigned to {ds.Name}.";
        }

        public string GenerateReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Security:");
            foreach (var ds in  sm.DefensiveSoftwares.Models.OrderBy(x => x.Name))
            {
                sb.AppendLine(ds.ToString());
            }
            sb.AppendLine("Threads:");
            sb.AppendLine("-Mitigated:");
            foreach(var ca in sm.CyberAttacks.Models.Where(x => x.Status).OrderBy(x => x.AttackName))
            {
                sb.AppendLine(ca.ToString());
            }
            sb.AppendLine("-Pending:");
            foreach (var ca in sm.CyberAttacks.Models.Where(x =>!x.Status).OrderBy(x => x.AttackName))
            {
                sb.AppendLine(ca.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string MitigateAttack(string cyberAttackName)
        {
            var ca = sm.CyberAttacks.GetByName(cyberAttackName);
            if (ca == null)
            {
                return $"{cyberAttackName} does not exist in the system.";
            }
            if (ca.Status)
            {
                return $"{cyberAttackName} is already mitigated.";
            }
            var ds = sm.DefensiveSoftwares.Models.FirstOrDefault(x => x.AssignedAttacks.Contains(cyberAttackName));
            if (ds == null)
            {
                return $"{cyberAttackName} is not assigned yet.";
            }
            if ((ca.GetType().Name == nameof(MalwareAttack) && ds.GetType().Name == nameof(Antivirus))
                || (ca.GetType().Name == nameof(PhishingAttack) && ds.GetType().Name == nameof(Firewall)))
            {
                return $"{ds.GetType().Name} cannot mitigate {ca.GetType().Name}.";
            }
            if (ds.Effectiveness >= ca.SeverityLevel)
            {
                ca.MarkAsMitigated();
                return $"{cyberAttackName} is mitigated successfully.";
            }
            return $"{cyberAttackName} could not be mitigated by {ds.Name}.";
        }
    }
}
