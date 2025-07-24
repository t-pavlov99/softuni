using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    internal class HelloCommand : Core.Contracts.ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {string.Join(' ', args)}";
        }
    }
}
