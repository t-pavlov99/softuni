using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataStructures;

internal class CustomStack : CustomList
{
    public void Push(int element)
    {
        this.Add(element);
    }

    public int Pop()
    {
        return this.RemoveAt(this.Count - 1);
    }

    public int Peek()
    {
        return this[this.Count - 1];
    }

    public void ForEach(Action<int> action)
    {
        for (int i = 0; i <  this.Count; i++)
        {
            action(this[i]);
        }
    }

}
