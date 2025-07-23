using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _03.Telephony
{
    internal abstract class Phone
    {
        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                
                phoneNumber = value;
            }
        }
        public abstract string Call();
    }
}
