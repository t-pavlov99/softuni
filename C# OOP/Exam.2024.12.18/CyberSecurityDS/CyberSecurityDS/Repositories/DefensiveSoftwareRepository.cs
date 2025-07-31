using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Repositories
{
    internal class DefensiveSoftwareRepository : IRepository<IDefensiveSoftware>
    {
        public DefensiveSoftwareRepository()
        {
            _models = new List<IDefensiveSoftware>();
        }

        private List<IDefensiveSoftware> _models;
        public IReadOnlyCollection<IDefensiveSoftware> Models => _models.AsReadOnly();

        public void AddNew(IDefensiveSoftware model)
        {
            _models.Add(model);
        }

        public bool Exists(string name)
        {
            return _models.Any(x => x.Name== name);
        }

        public IDefensiveSoftware GetByName(string name)
        {
            return _models.FirstOrDefault(x => x.Name == name);
        }
    }
}
