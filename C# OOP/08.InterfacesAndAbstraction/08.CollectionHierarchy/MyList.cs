using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CollectionHierarchy
{
    internal class MyList : StringCollection, IAdder, IRemover
    {
        public MyList() : base() { }
        public MyList(List<string> strings) : base(strings)
        {
        }

        public override int Add(string item)
        {
            strings.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string removed = strings[0];
            strings.RemoveAt(0);
            return removed;
        }

        public int Used { get { return strings.Count; } }
    }
}
