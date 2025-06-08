using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataStructures;
internal class CustomQueue : CustomList
{
    public void Enqueue (int element)
    {
        this.Add(element);
    }

    public int Dequeue()
    {
        return this.RemoveAt(0);
    }

    public int Peek()
    {
        return this[0];
    }

    public void Clear()
    {
        while (this.Count > 0)
        {
            Dequeue();
        }
    }
    
}
