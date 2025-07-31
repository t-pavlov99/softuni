using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Core
{
    internal class Controller : IController
    {
        private BankRepository banks;
        private LoanRepository loans;

        public Controller()
        {
            banks = new BankRepository();
            loans = new LoanRepository();
        }
        public string AddBank(string bankTypeName, string name)
        {
            if (bankTypeName != nameof(CentralBank) && bankTypeName != nameof(BranchBank))
            {
                throw new ArgumentException("Invalid bank type.");
            }
            IBank bank;
            if (bankTypeName == nameof(BranchBank))
            {
                bank = new BranchBank(name);
            }
            else
            {
                bank = new CentralBank(name);
            }
            banks.AddModel(bank);
            return $"{bankTypeName} is successfully added.";
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            IClient client;
            if (clientTypeName == nameof(Student))
            {
                client = new Student(clientName, id, income);
            }
            else if (clientTypeName == nameof(Adult))
            {
                client = new Adult(clientName, id, income);
            }
            else
            {
                throw new ArgumentException("Invalid client type.");
            }
            IBank bank = banks.FirstModel(bankName);
            if ((bank.GetType().Name == nameof(CentralBank) && clientTypeName == nameof(Student))
                || (bank.GetType().Name == nameof(BranchBank) && clientTypeName == nameof(Adult)))
            {
                return "Unsuitable bank.";
            }
            bank.AddClient(client);
            return $"{clientTypeName} successfully added to {bankName}.";

        }

        public string AddLoan(string loanTypeName)
        {
            ILoan loan;
            if (loanTypeName == nameof(StudentLoan))
            {
                loan = new StudentLoan();
            }
            else if (loanTypeName == nameof(MortgageLoan))
            {
                loan = new MortgageLoan();
            }
            else
            {
                throw new ArgumentException("Invalid loan type.");
            }
            loans.AddModel(loan);
            return $"{loanTypeName} is successfully added.";
        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = banks.FirstModel(bankName);
            return $"The funds of bank {bankName} are {bank.Clients.Sum(x => x.Income) + bank.Loans.Sum(x => x.Amount):f2}.";
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = loans.FirstModel(loanTypeName);
            if (loan == null)
            {
                throw new ArgumentException($"Loan of type {loanTypeName} is missing.");
            }
            IBank bank = banks.FirstModel(bankName);
            bank.AddLoan(loan);
            loans.RemoveModel(loan);
            return $"{loanTypeName} successfully added to {bankName}.";
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IBank bank in banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }
            return sb.ToString().Trim();
        }
    }
}
