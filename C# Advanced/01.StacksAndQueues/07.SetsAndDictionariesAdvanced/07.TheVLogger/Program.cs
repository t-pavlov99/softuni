/*
EmilConrad joined The V-Logger
VenomTheDoctor joined The V-Logger
Saffrona joined The V-Logger
Saffrona followed EmilConrad
Saffrona followed VenomTheDoctor
EmilConrad followed VenomTheDoctor
VenomTheDoctor followed VenomTheDoctor
Saffrona followed EmilConrad
Statistics

JennaMarbles joined The V-Logger
JennaMarbles followed Zoella
AmazingPhil joined The V-Logger
JennaMarbles followed AmazingPhil
Zoella joined The V-Logger
JennaMarbles followed Zoella
Zoella followed AmazingPhil
Christy followed Zoella
Zoella followed Christy
JacksGap joined The V-Logger
JacksGap followed JennaMarbles
PewDiePie joined The V-Logger
Zoella joined The V-Logger
Statistics
*/
using System.Collections.Immutable;

namespace _07.TheVLogger
{
    internal class Program
    {
        static Dictionary<string, (int, SortedSet<string>)> vloggers;
        static void Main(string[] args)
        {
            string cmd;
            vloggers = new();
            while ((cmd = Console.ReadLine()) != "Statistics")
            {
                string[] parts = cmd.Split();
                switch (parts[1])
                {
                    case "joined":
                        AddVlogger(parts[0]);
                        break;
                    case "followed":
                        AddFollower(parts[2], parts[0]);
                        break;
                    default: break;
                }
            }
            PrintStatistics();
        }

        static void AddVlogger(string name)
        {
            if (!vloggers.ContainsKey(name))
            {
                vloggers.Add(name, (0, new()));
            }
        }

        static void AddFollower(string vlogger, string follower)
        {
            if (vlogger == follower)
                return;
            if (!vloggers.ContainsKey(vlogger))
                return;
            if (!vloggers.ContainsKey(follower))
                return;
            if (vloggers[vlogger].Item2.Contains(follower))
                return;
            vloggers[vlogger].Item2.Add(follower);
            if (vloggers.ContainsKey(follower))
            {
                vloggers[follower] = (vloggers[follower].Item1 + 1, vloggers[follower].Item2);
            }
        }

        static void PrintStatistics()
        {
            var sorted = vloggers.OrderByDescending(x => x.Value.Item2.Count).ThenBy(x => x.Value.Item1);
            int counter = 1;
            Console.WriteLine($"The V-Logger has a total of {sorted.Count()} vloggers in its logs.");
            foreach (var vlogger in sorted)
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.Item2.Count} followers, {vlogger.Value.Item1} following");
                if (counter == 1)
                {
                    foreach (string follower in vlogger.Value.Item2)
                        Console.WriteLine("*  " + follower);
                }
                counter++;
            }
            
        }
    }
}
