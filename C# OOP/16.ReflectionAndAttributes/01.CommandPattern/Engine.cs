using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    internal class Engine : Core.Contracts.IEngine
    {
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        private readonly ICommandInterpreter commandInterpreter;
        public void Run()
        {
            string cmd;

            while (true)
            {
                cmd = Console.ReadLine();
                string result = commandInterpreter.Read(cmd);
                if (result != null)
                {
                    Console.WriteLine(result);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
