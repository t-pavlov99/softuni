using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    internal abstract class Loan : ILoan
    {
        public Loan(int interestRate, double amount)
        {
            this.InterestRate = interestRate;
            this.Amount = amount;
        }

        private int _interestRate;
        private double _amount;
        public int InterestRate
        {
            get { return _interestRate; }
            private set { _interestRate = value; }
        }
        public double Amount
        {
            get { return _amount; }
            private set { _amount = value; }
        }
    }
}
