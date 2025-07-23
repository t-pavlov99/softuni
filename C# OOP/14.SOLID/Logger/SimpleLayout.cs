using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal class SimpleLayout : ILayout
    {
        public string Compose(Log log)
        {
            return $"{log.DateTime} - {log.ReportLevel} - {log.Message}";
        }
    }
}
