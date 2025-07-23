using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal class CommandInterpreter
    {
        public static Logger logger;
        private static int N;
        private static IAppender[] appenders;
        public static void AddAppenders()
        {
            N = int.Parse(Console.ReadLine());
            appenders = new IAppender[N];
            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split();
                string type = input[0];
                string layoutString = input[1];
                string level = input.Length == 3 ? input[2] : "INFO";
                ILayout layout = layoutString == "SimpleLayout" ? new SimpleLayout() : new XmlLayout();
                switch (type)
                {
                    case "ConsoleAppender":
                        appenders[i] = new ConsoleAppender(layout, level);
                        break;
                    case "FileAppender":
                        appenders[i] = new FileAppender(layout, new LogFile(), level);
                        break;

                }
            }
            logger = new Logger(appenders);
        }

        public static void ProduceReport()
        {
            Console.WriteLine(logger.ToString());
            
        }

        internal static void ProcessLogs()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] parts = input.Split("|");
                string type = parts[0];
                string datetime = parts[1];
                string message = parts[2];
                logger.Log(type, datetime, message);
            }
        }

        internal static string NormalizeName(string name)
        {
            name = name.ToLower();
            char firstLetter = (char)((int)name[0] + (int)'A' - (int)'a');
            return firstLetter + name.ToLower().Substring(1);
        }
    }
}
