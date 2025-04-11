namespace _06.SongsQueue
{
    /*
All Over Again, Watch Me
Play
Add Watch Me
Add Love Me Harder
Add Promises
Show
Play
Play
Play
Play
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new(Console.ReadLine().Split(", "));
            string cmd;
            while (true)
            {
                cmd = Console.ReadLine();
                switch (cmd[0])
                {
                    case 'P':
                        songs.Dequeue();
                        if (songs.Count == 0)
                        {
                            Console.WriteLine("No more songs!");
                            return;
                        }
                        break;
                    case 'A':
                        string song = cmd.Substring(4);
                        if (songs.Contains(song))
                        {
                            Console.WriteLine(song + " is already contained!");
                        }
                        else
                        {
                            songs.Enqueue(song);
                        }
                        break;
                    case 'S':
                        Console.WriteLine(string.Join(", ", songs));
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
