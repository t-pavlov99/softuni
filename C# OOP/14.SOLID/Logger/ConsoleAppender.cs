using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal class ConsoleAppender : Appender, IAppender
    {
        public ConsoleAppender(ILayout layout, string threshold = "INFO") : base(layout, threshold) { }

        protected override void AddLog(Log log)
        {
            Console.WriteLine(Layout.Compose(log));
        }

        
    }
}
