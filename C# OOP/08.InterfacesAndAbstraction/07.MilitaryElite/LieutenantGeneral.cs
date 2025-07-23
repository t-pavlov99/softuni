using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite
{
    internal class LieutenantGeneral : RegularSoldier, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            privates = new List<IPrivate>();
        }

        private List<IPrivate> privates;
        public IReadOnlyCollection<IPrivate> Privates { get => privates.AsReadOnly(); }

        public void AddPrivate(IPrivate priv)
        {
            privates.Add(priv);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append("Privates:");
            foreach (IPrivate priv in Privates)
            {
                sb.Append($"\n  {priv.ToString()}");
            }
            return sb.ToString();
        }
    }
}
