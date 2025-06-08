using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataStructures;

internal class CustomList
{
    private static int InitialCapacity = 10;
    private int[] elements;
    private int length;

    public int Count { get; private set; }
    public CustomList() : this(InitialCapacity) { }
    public CustomList(int count)
    {
        elements = new int[count];
        this.Count = 0;
        this.length = 0;
    }

    public CustomList(int[] elements)
    {
        this.elements = elements;
        length = elements.Length;
        Count = length;
    }

    public int this[int index]
    {
        get
        {
            if (!ValidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }
            return elements[index];
        }
        set
        {
            if (!ValidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }
            elements[index] = value;
        }
    }

    private void Enlarge()
    {
        length *= 2;
        int[] newArray = new int[length];
        for (int i = 0; i < Count; i++)
        {
            newArray[i] = elements[i];
        }
        elements = newArray;
    }
    public void Add(int element)
    {
        if (length == Count)
        {
            Enlarge();
        }
        elements[Count++] = element;
    }

    public bool ValidIndex(int index)
    {
        return index >= 0 && index < Count;
    }
    public int RemoveAt(int index)
    {
        if (!ValidIndex(index))
        {
            throw new ArgumentOutOfRangeException();
        }
        int value = elements[index];
        for (int i = index; i < Count - 1; i++)
        {
            elements[i] = elements[i + 1];
        }
        return value;
    }

    public bool Contains(int element)
    {
        for (int i = 0; i < Count; i++)
        {
            if (elements[i] == element)
                return true;
        }
        return false;
    }

    public int IndexOf(int element)
    {
        for (int i = 0; i < Count; i++)
        {
            if (elements[i] == element)
                return i;
        }
        return -1;
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        if (!ValidIndex(firstIndex) || !ValidIndex(secondIndex))
        {
            throw new ArgumentOutOfRangeException();
        }
        int temp = elements[firstIndex];
        elements[firstIndex] = elements[secondIndex];
        elements[secondIndex] = temp;
    }

    public void Insert(int index, int element)
    {
        if (index > Count || index < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (this.length == this.Count)
        {
            Enlarge();
        }
        for (int i = this.Count; i > index; i--)
        {
            this.elements[i] = elements[i - 1];
        }
        this.elements[index] = element;
        this.Count++;

    }
}
