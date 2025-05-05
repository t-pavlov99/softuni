using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ListyIterator;

internal class ListyIterator<T>
{
    private List<T> elements;
    private int index;
    public ListyIterator(params T[] elements)
    {
        this.elements = new List<T>(elements);
        index = 0;
    }

    public bool HasNext()
    {
        return index < elements.Count - 1;
    }
    public bool Move()
    {
        if (HasNext())
        {
            index++;
            return true;
        }
        return false;
    }

    public void Print()
    {
        if (elements.Count == 0)
        {
            throw new Exception("Invalid Operation!");
            
        }
        Console.WriteLine(this.elements[index]);
    }
}
