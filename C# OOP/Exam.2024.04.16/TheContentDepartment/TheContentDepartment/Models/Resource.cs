using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    internal abstract class Resource : IResource
    {
        private Resource(string name, string creator, int priority, bool isTested, bool isApproved)
        {
            Name = name;
            Creator = creator;
            _priority = priority;
            IsTested = isTested;
            IsApproved = isApproved;
        }
        protected Resource(string name, string creator, int priority) : this(name, creator, priority, false, false)
        {
        }

        private string _name;
        private string _creator;
        private readonly int _priority;
        private bool _isTested;
        private bool _isApproved;
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.NameNullOrWhiteSpace);
                }
                _name = value;
            }
        }

        public string Creator
        {
            get => _creator;
            private set
            {
                _creator = value;
            }
        }

        public int Priority { get => _priority; }

        public bool IsTested { get => _isTested; private set => _isTested = value; }

        public bool IsApproved { get => _isApproved; private set => _isApproved = value; }

        public void Approve()
        {
            IsApproved = true;
        }

        public void Test()
        {
            IsTested = !IsTested;
        }

        public override string ToString()
        {
            return $"{Name} ({GetType().Name}), Created By: {Creator}";
        }
    }
}
