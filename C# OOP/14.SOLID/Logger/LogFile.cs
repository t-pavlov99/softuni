using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal class LogFile
    {
        public LogFile()
        {
            messages = new StringBuilder();
        }

        public StringBuilder messages;

        public void Write(string message)
        {
            messages.Append(message);
        }

        public int Size
        {
            get
            {
                int sum = 0;
                foreach (char c in messages.ToString())
                {
                    if (char.IsLetter(c))
                        sum += c;

                }
                return sum;
            }
        }
    }


}
