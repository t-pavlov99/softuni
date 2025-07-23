using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CollectionHierarchy
{
    internal class AddRemoveCollection : StringCollection, IRemover
    {
        public AddRemoveCollection() : base() { }
        public AddRemoveCollection(List<string> strings) : base(strings)
        {
        }

        public override int Add(string item)
        {
            strings.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string removed = strings.Last();
            strings.RemoveAt(strings.Count - 1);
            return removed;
        }
    }
}
