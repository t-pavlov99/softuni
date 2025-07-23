using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal class Log
    {
        public Log(string dateTime, string reportLevel, string message)
        {
            DateTime = dateTime;
            ReportLevel = reportLevel;
            Message = message;
        }
        public string DateTime { get; set; }
        public string ReportLevel { get; set; }
        public string Message { get; set; }

    }
}
