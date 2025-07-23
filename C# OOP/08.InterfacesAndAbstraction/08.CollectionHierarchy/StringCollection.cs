using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CollectionHierarchy
{
    internal abstract class StringCollection : IAdder
    {
        protected List<string> strings;

        public StringCollection()
        {
            strings = new List<string>();
        }
        public StringCollection(List<string> strings) : this()
        {
            foreach (var item in strings)
            {
                Add(item);
            }
        }
        public abstract int Add(string item);
    }
}
