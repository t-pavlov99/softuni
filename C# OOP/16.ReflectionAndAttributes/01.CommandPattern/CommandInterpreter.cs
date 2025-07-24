using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    internal class CommandInterpreter : Core.Contracts.ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] parts = args.Split(' ');
            string type = parts[0] + "Command";
            string[] arguments = parts.Skip(1).ToArray();

            Type cmdType = Assembly.GetEntryAssembly().GetTypes().Where(x => x.Name == type).FirstOrDefault();

            ICommand cmd = Activator.CreateInstance(cmdType) as ICommand;
            return cmd.Execute(arguments);
        }
    }
}
