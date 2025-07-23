namespace _08.CollectionHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = Console.ReadLine().Split().ToList();

            AddCollection ac = new AddCollection();
            AddRemoveCollection arc = new AddRemoveCollection();
            MyList ml = new MyList();
            
            int removeCount = int.Parse(Console.ReadLine());

            int[,] values = new int[3, strings.Count];
            for (int i = 0; i < strings.Count; i++)
            {
                values[0, i] = ac.Add(strings[i]);
                values[1, i] = arc.Add(strings[i]);
                values[2, i] = ml.Add(strings[i]);
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < strings.Count; j++)
                {
                    Console.Write(values[i, j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < removeCount; i++)
            {
                Console.Write(arc.Remove() + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < removeCount; i++)
            {
                Console.Write(ml.Remove() + " ");
            }
        }
    }
}
