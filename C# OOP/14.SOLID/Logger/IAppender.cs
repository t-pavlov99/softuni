using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal interface IAppender
    {
        ILayout Layout { get; }
        void Append(Log log);
    }
}
