using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CollectionHierarchy
{
    internal class AddCollection : StringCollection, IAdder
    {
        public AddCollection() : base() { }
        public AddCollection(List<string> strings) : base(strings)
        {
        }

        public override int Add(string item)
        {
            strings.Add(item);
            return strings.Count - 1;
        }
    }
}
