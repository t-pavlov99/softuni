using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Repositories
{
    internal class CyberAttackRepository : IRepository<ICyberAttack>
    {
        public CyberAttackRepository()
        {
            _models = new List<ICyberAttack>();
        }

        private List<ICyberAttack> _models;
        public IReadOnlyCollection<ICyberAttack> Models => _models.AsReadOnly();

        public void AddNew(ICyberAttack model)
        {
            _models.Add(model);
        }

        public bool Exists(string name)
        {
            return _models.Any(x => x.AttackName == name);
        }

        public ICyberAttack GetByName(string name)
        {
            return _models.FirstOrDefault(x => x.AttackName == name);
        }
    }
}
