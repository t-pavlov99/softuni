using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal interface ILogger
    {
        List<IAppender> Appenders { get; }

        void Error(string dateTime, string message);
        void Fatal(string dateTime, string message);
        void Warning(string dateTime, string message);
        void Info(string dateTime, string message);
        void Critical(string dateTime, string message);
    }
}
