using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    internal class BankRepository : IRepository<IBank>
    {
        public BankRepository()
        {
            _models = new List<IBank>();
        }

        private List<IBank> _models;
        public IReadOnlyCollection<IBank> Models => _models.AsReadOnly();

        public void AddModel(IBank model)
        {
            _models.Add(model);
        }

        public IBank FirstModel(string name)
        {
            return _models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveModel(IBank model)
        {
            return _models.Remove(model);
        }
    }
}
