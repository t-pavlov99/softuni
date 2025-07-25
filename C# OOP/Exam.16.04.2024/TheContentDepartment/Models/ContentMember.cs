using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    internal class ContentMember : TeamMember
    {

        private static List<string> _allowedPaths = new List<string> { "CSharp", "JavaScript", "Python", "Java" };
        private string _path;
        public ContentMember(string name, string path) : base(name, path)
        {
            if (!_allowedPaths.Contains(path))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, path));
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Path} path. Currently working on {InProgress.Count} tasks.";
        }
    }
}
