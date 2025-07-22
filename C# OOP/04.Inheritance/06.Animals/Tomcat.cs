using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    internal class Tomcat : Cat
    {
        public Tomcat(string name, int age) : base(name, age, "Male")
        {
        }

        public string ProduceSound()
        {
            return "MEOW";
        }
    }
}
