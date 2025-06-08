namespace ImplementingLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList dll = new DoublyLinkedList();
            for (int i = 0; i < 10; i++)
            {
                dll.AddLast(i);
            }
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                    dll.RemoveFirst();
                else
                    dll.RemoveLast();
                dll.ForEach(x => Console.Write($"{x} "));
                Console.WriteLine();
            }
            
        }
    }
}
