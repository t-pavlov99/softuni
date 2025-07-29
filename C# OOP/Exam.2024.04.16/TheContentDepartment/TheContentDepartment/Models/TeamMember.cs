using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    internal abstract class TeamMember : ITeamMember
    {
        protected TeamMember(string name, string path)
        {
            Name = name;
            Path = path;
            _inProgress = new List<string>();
        }

        private string _name;
        private List<string> _inProgress;
        private string _path;

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                _name = value;
            }
        }

        public string Path { get => _path; protected set => _path = value; }
        public IReadOnlyCollection<string> InProgress { get => _inProgress.AsReadOnly(); }

        public void FinishTask(string resourceName)
        {

            _inProgress.Remove(resourceName);
        }

        public void WorkOnTask(string resourceName)
        {
            if (!_inProgress.Contains(resourceName))
                _inProgress.Add(resourceName);
        }
    }
}
