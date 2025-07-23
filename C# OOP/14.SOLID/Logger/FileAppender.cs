using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal class FileAppender : Appender
    {
        public LogFile logFile;

        public FileAppender(ILayout layout, LogFile logFile, string threshold = "INFO") : base(layout, threshold)
        {
            this.logFile = logFile;
        }


        protected override void AddLog(Log log)
        {
            logFile.Write(Layout.Compose(log));
        }

        public override string ToString()
        {
            return base.ToString() + $", File size {logFile.Size}";
        }
    }
}
