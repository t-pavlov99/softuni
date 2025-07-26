using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    internal class TeamLead : TeamMember
    {
        private static List<string> _allowedPaths = new List<string> { "Master" };
        private string _path;
        public TeamLead(string name, string path) : base(name, path)
        {
            if (!_allowedPaths.Contains(path))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, path));
            }
        }

        public override string ToString()
        {
            return $"{Name} ({GetType().Name}) - Currently working on {InProgress.Count} tasks.";
        }
    }
}
