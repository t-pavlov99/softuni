using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Stack;

internal class CustomStack<T> : IEnumerable<T>
{
    private List<T> _elements;

    public CustomStack(params T[] values)
    {
        _elements = values.ToList();
    }

    public void Push(T element)
    {
        _elements.Add(element);
    }

    public T Pop()
    {
        if ( _elements.Count > 0 )
        {
            T elem = _elements[_elements.Count - 1];
            _elements.RemoveAt(_elements.Count - 1);
            return elem;
        }
        throw new Exception("No elements");
    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = _elements.Count - 1; i >= 0; i--)
        {
            yield return _elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
