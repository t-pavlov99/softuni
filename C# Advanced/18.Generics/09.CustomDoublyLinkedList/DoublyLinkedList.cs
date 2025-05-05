using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList;

internal class DoublyLinkedList<T>
{
    private class ListNode
    {
        public T Value { get; set; }
        public ListNode NextNode { get; set; }
        public ListNode PreviousNode { get; set; }
        public ListNode(T value)
        {
            this.Value = value;
        }
    }

    private ListNode head;
    private ListNode tail;
    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        if (this.Count == 0)
        {
            this.head = new ListNode(element);
            this.tail = this.head;
        }
        else
        {
            ListNode newHead = new ListNode(element);
            newHead.NextNode = this.head;
            this.head.PreviousNode = newHead;
            this.head = newHead;
        }
        this.Count++;
    }

    public void AddLast(T element)
    {
        if (this.Count == 0)
        {
            this.tail = new ListNode(element);
            this.head = this.tail;
        }
        else
        {
            ListNode newHead = new ListNode(element);
            newHead.PreviousNode = this.tail;
            this.tail.NextNode = newHead;
            this.tail = newHead;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The list is empty");
        }
        T value = head.Value;
        if (Count != 1)
        {
            this.head = this.head.NextNode;
            this.head.PreviousNode = null;
        }
        else
        {
            this.head = null;
            this.tail = null;
        }
        this.Count--;
        return value;

    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The list is empty");
        }
        T value = this.tail.Value;
        if (Count != 1)
        {
            this.tail = this.tail.PreviousNode;
            this.tail.NextNode = null;
        }
        else
        {
            this.head = null;
            this.tail = null;
        }
        this.Count--;
        return value;
    }

    public void ForEach(Action<T> action)
    {
        ListNode current = this.head;

        while (current != null)
        {
            action(current.Value);
            current = current.NextNode;
        }
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        ListNode current = this.head;
        for (int i = 0; i < this.Count; i++)
        {
            array[i] = current.Value;
            current = current.NextNode;
        }
        return array;
    }

}
