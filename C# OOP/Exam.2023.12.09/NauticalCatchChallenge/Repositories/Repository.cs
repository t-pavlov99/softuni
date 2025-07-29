using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Repositories
{
    internal abstract class Repository<T> : IRepository<T> where T : class
    {
        public Repository()
        {
            _models = new List<T>();
        }

        protected List<T> _models;
        public IReadOnlyCollection<T> Models => _models.AsReadOnly();

        public void AddModel(T model)
        {
            _models.Add(model);
        }

        public abstract T GetModel(string name);
    }
}
