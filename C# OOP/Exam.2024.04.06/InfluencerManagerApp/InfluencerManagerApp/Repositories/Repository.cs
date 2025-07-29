using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Repositories
{
    internal abstract class Repository<T> : IRepository<T> where T : class
    {
        public Repository()
        {
            _models = new List<T>();
        }

        protected List<T> _models;
        public IReadOnlyCollection<T> Models { get => _models.AsReadOnly(); }

        public void AddModel(T model)
        {
            _models.Add(model);
        }

        public abstract T FindByName(string name);

        public bool RemoveModel(T model)
        {
            return _models.Remove(model);
        }
    }
}
