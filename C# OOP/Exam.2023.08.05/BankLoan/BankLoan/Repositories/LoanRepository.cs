using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    internal class LoanRepository : IRepository<ILoan>
    {
        public LoanRepository()
        {
            _models = new List<ILoan>();    
        }

        private List<ILoan> _models;
        public IReadOnlyCollection<ILoan> Models => _models.AsReadOnly();

        public void AddModel(ILoan model)
        {
            _models.Add(model);
        }

        public ILoan FirstModel(string name)
        {
            return _models.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveModel(ILoan model)
        {
            return _models.Remove(model);
        }
    }
}
