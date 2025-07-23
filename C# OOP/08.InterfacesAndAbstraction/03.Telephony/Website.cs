using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Telephony
{
    internal class Website
    {
        private string address;
        public string Address
        {
            get => address;
            set
            {
                
                address = value;
            }
        }

        public string Browse()
        {
            for (char c = '0'; c <= '9'; c++)
                if (address.Contains(c))
                    return "Invalid URL!";
            return "Browsing: " + address + "!";

        }

        public Website(string address)
        {
            Address = address;
        }

    }
}
