using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal class XmlLayout : ILayout
    {
        public string Compose(Log log)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine($"    <date>{log.DateTime}</date>");
            sb.AppendLine($"    <level>{log.ReportLevel}</level>");
            sb.AppendLine($"    <message>{log.Message}</message>");
            sb.AppendLine("</log>");
            return sb.ToString();
        }
    }
}
