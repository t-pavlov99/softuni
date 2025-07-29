using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    internal class PlayerRepository : IRepository<IPlayer>
    {
        public PlayerRepository()
        {
            _models = new List<IPlayer>();
        }

        private List<IPlayer> _models;
        public IReadOnlyCollection<IPlayer> Models => _models.AsReadOnly();

        public void AddModel(IPlayer model)
        {
            _models.Add(model);
        }

        public bool ExistsModel(string name)
        {
            return _models.Any(x => x.Name == name);
        }

        public IPlayer GetModel(string name)
        {
            return _models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveModel(string name)
        {
            return _models.Remove(GetModel(name));
        }
    }
}
