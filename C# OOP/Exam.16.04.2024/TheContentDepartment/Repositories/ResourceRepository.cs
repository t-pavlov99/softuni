using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
    internal class ResourceRepository : IRepository<IResource>
    {
        public ResourceRepository()
        {
            _models = new List<IResource>();
        }

        private List<IResource> _models;
        public IReadOnlyCollection<IResource> Models { get => _models.AsReadOnly(); }

        public void Add(IResource model)
        {
            _models.Add(model);
        }

        public IResource TakeOne(string modelName)
        {
            if (_models.Any(x => x.Name == modelName))
            {
                return _models.First(x => x.Name == modelName);
            }
            return null;
        }
    }
}
