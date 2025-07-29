using BlackFriday.Models.Contracts;
using BlackFriday.Models;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Repositories
{
    internal class ProductRepository : IRepository<IProduct>
    {
        private List<IProduct> _models;
        public ProductRepository()
        {
            _models = new List<IProduct>();
        }

        public IReadOnlyCollection<IProduct> Models => _models.AsReadOnly();

        public void AddNew(IProduct model)
        {
            _models.Add(model);
        }

        public bool Exists(string name)
        {
            return _models.Any(x => x.ProductName == name);
        }

        public IProduct GetByName(string name)
        {
            return _models.FirstOrDefault(x => x.ProductName == name);
        }
    }
}
