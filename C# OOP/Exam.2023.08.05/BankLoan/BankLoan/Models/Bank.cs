using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    internal abstract class Bank : IBank
    {
        public Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            _loans = new List<ILoan>();
            _clients = new List<IClient>();
        }
        private string _name;
        private int _capacity;
        private List<ILoan> _loans;
        private List<IClient> _clients;
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Bank name cannot be null or empty.");
                _name = value;
            }
        }

        public int Capacity
        {
            get { return _capacity; }
            private set { _capacity = value; }
        }

        public IReadOnlyCollection<ILoan> Loans => _loans.AsReadOnly();

        public IReadOnlyCollection<IClient> Clients => _clients.AsReadOnly();
        public void AddClient(IClient Client)
        {
            if (_clients.Count == Capacity)
            {
                throw new ArgumentException("Not enough capacity for this client.");
            }
            _clients.Add(Client);
        }

        public void AddLoan(ILoan loan)
        {
            _loans.Add(loan);
        }

        public string GetStatistics()
        {

            string clients = _clients.Count == 0 ? "none" : string.Join(", ", _clients.Select(x => x.Name));
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}, Type: {GetType().Name}");
            sb.AppendLine($"Clients: {clients}");
            sb.AppendLine($"Loans: {_loans.Count}, Sum of Rates: {SumRates()}");
            return sb.ToString().Trim();
        }

        public void RemoveClient(IClient client)
        {
            _clients.Remove(client);
        }

        public double SumRates()
        {
            return _loans.Sum(x => x.InterestRate);
        }
    }
}
