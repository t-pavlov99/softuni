using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
    internal abstract class Repository<T> : IRepository<T> where T : class
    {
        public Repository()
        {
            _all = new List<T>();
        }

        protected List<T> _all;
        public IReadOnlyCollection<T> All => _all.AsReadOnly();

        public void Add(T model)
        {
            _all.Add(model);
        }

        public abstract T Get(string name);
    }
}
