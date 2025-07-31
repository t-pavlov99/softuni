using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Repositories
{
    internal class SystemManager
    {

        public SystemManager()
        {
            _attacks = new CyberAttackRepository();
            _softwares = new DefensiveSoftwareRepository();
        }

        private IRepository<ICyberAttack> _attacks;
        private IRepository<IDefensiveSoftware> _softwares;

        public IRepository<ICyberAttack> CyberAttacks
        {
            get { return _attacks; }
            private set { _attacks = value; }
        }

        public IRepository<IDefensiveSoftware> DefensiveSoftwares
        {
            get { return _softwares; }
            private set { _softwares = value; }
        }

    }
}
