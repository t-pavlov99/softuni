using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite
{
    internal class Mission : IMission
    {
        private string state;
        public string CodeName { get; set; }

        public string State
        {
            get => state;
            private set
            {
                if (value != "InProgress" && value != "Finished")
                    throw new ArgumentException("Inavlid state.");
                state = value;
            }
        }

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }
        public void CompleteMission()
        {
            State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
