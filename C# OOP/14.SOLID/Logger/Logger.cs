using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = appenders.ToList();
        }

        public Logger(List<IAppender> appenders)
        {
            Appenders = appenders;
        }
        
        public List<IAppender> Appenders {  get; private set; }

        private void Log(Log log)
        {
            foreach (Appender appender in Appenders)
                appender.Append(log);
        }
        public void Error(string dateTime, string message)
        {
            Log(new Log(dateTime, "Error", message));
        }

        public void Fatal(string dateTime, string message)
        {
            Log(new Log(dateTime, "Fatal", message));
        }

        public void Warning(string dateTime, string message)
        {
            Log(new Log(dateTime, "Warning", message));
        }

        public void Info(string dateTime, string message)
        {
            Log(new Log(dateTime, "Info", message));
        }

        public void Critical(string dateTime, string message)
        {
            Log(new Log(dateTime, "Critical", message));
        }

        public void Log(string type, string dateTime, string message)
        {
            switch (type.ToLower())
            {
                case "critical": Critical(dateTime, message); break;
                case "info": Info(dateTime, message); break;
                case "warning": Warning(dateTime, message); break;
                case "error": Error(dateTime, message); break;
                case "fatal": Fatal(dateTime, message); break;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Logger info");
            foreach (IAppender appender in Appenders)
            {
                sb.Append("\n" + appender.ToString());
            }
            return sb.ToString();
        }
    }
}
