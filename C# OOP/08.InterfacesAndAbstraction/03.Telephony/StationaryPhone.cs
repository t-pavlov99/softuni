using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Telephony
{
    internal class StationaryPhone : Phone
    {
        public StationaryPhone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public override string Call()
        {
            foreach (char c in PhoneNumber)
            {
                if (c < '0' || c > '9')
                    return "Invalid number!";
            }
            return $"Dialing... {PhoneNumber}";
        }
    }
}
