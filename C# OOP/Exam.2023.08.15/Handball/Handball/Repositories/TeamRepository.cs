using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    internal class TeamRepository : IRepository<ITeam>
    {
        public TeamRepository()
        {
            _models = new List<ITeam>();
        }

        private List<ITeam> _models;
        public IReadOnlyCollection<ITeam> Models => _models.AsReadOnly();

        public void AddModel(ITeam model)
        {
            _models.Add(model);
        }

        public bool ExistsModel(string name)
        {
            return _models.Any(x => x.Name == name);
        }

        public ITeam GetModel(string name)
        {
            return _models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveModel(string name)
        {
            return _models.Remove(GetModel(name));
        }
    }
}
