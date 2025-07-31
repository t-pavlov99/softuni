using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    internal abstract class Client : IClient
    {
        public Client(string name, string id, int interest, double income)
        {
            Name = name;
            Id = id;
            Interest = interest;
            Income = income;

        }
        private string _name;
        private string _id;
        private int _interest;
        private double _income;
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Client name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public string Id
        {
            get { return _id; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Client’s ID cannot be null or empty."
);
                }
                _id = value;
            }
        }

        public int Interest
        {
            get { return _interest; }
            protected set { _interest = value; }
        }

        public double Income
        {
            get { return _income; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Income cannot be below or equal to 0.");
                }
                _income = value;
            }
        }

        public abstract void IncreaseInterest();
    }
}
