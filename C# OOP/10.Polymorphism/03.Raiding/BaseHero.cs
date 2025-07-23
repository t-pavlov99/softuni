using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding
{
    internal abstract class BaseHero
    {
        public string Name { get; protected set; }
        public int Power { get; protected set; }
        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} ";
        }

        public BaseHero(string name)
        {
            Name = name;
        }
    }
}
