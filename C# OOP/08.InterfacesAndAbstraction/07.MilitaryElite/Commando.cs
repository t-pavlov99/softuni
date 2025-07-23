using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite
{
    internal class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions { get => missions.AsReadOnly(); }

        public void AddMission(IMission mission)
        {
            missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append("Missions:");
            foreach (IMission mission in missions)
            {
                sb.Append($"\n  {mission.ToString()}");
            }
            return sb.ToString();
        }
    }
}
