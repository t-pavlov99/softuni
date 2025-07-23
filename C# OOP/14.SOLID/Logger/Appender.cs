using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal abstract class Appender : IAppender
    {
        private readonly Dictionary<string, int> ReportLevels = new Dictionary<string, int> { { "info", 0 }, { "warning", 1 }, { "error", 2 }, { "critical", 3 }, { "fatal", 4 } };
        public string ReportLevel { get; set; }
        public ILayout Layout { get; protected set; }

        private int messagesCount;
        public Appender(ILayout layout, string threshold = "INFO")
        {
            this.Layout = layout;
            this.ReportLevel = threshold;
            messagesCount = 0;
        }
        public void Append(Log log)
        {
            if (ReportLevels[log.ReportLevel.ToLower()] >= ReportLevels[ReportLevel.ToLower()])
            {
                AddLog(log);
                messagesCount++;
            }
        }

        protected abstract void AddLog(Log log);

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Append type: {GetType().Name}, Layout type: {Layout.GetType().Name}, ");
            stringBuilder.Append($"Report level: {ReportLevel}, Messages appended: {messagesCount}");
            return stringBuilder.ToString();
        }
    }
}
