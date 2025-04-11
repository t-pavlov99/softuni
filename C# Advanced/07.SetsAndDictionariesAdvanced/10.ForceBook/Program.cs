/*
Light | George
Dark | Peter
Lumpawaroo

Lighter | Royal
Darker | DCay
John Johnys -> Lighter
DCay -> Lighter
Lumpawaroo
 */

using System.Text.RegularExpressions;

namespace _10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new();
            Dictionary<string, int> sides = new();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Lumpawaroo")
            {
                string pattern = @"(.+) (\||(?:->)) (.+)";
                var match = Regex.Match(cmd, pattern);
                string user, side;
                switch (match.Groups[2].Value)
                {
                    case "|":

                        user = match.Groups[3].Value;
                        side = match.Groups[1].Value;
                        if (!users.ContainsKey(user))
                        {
                            users.Add(user, side);
                            if (!sides.ContainsKey(side))
                                sides.Add(side, 0);
                            sides[side]++;
                        }
                        break;
                    case "->":
                        user = match.Groups[1].Value;
                        side = match.Groups[3].Value;
                        
                        
                        if (!users.ContainsKey(user))
                        {
                            users.Add(user, side);
                            if (!sides.ContainsKey(side))
                                sides.Add(side, 0);
                            sides[side]++;
                        }
                        if (!sides.ContainsKey(side))
                            sides.Add(side, 1);
                        sides[users[user]]--;
                        users[user] = side;
                        sides[side]++;
                        Console.WriteLine($"{user} joins the {side} side!");
                        break;
                    default:
                        break;
                }
            }
            var ordered = sides.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
            foreach (var side in ordered)
            {
                if (side.Value == 0)
                    break;
                string[] sideUsers = users.Where(x => x.Value == side.Key).Select(x => x.Key).OrderBy(x => x).ToArray();
                Console.WriteLine($"Side: {side.Key}, Members: {sideUsers.Length}");
                foreach (string user in sideUsers)
                    Console.WriteLine("! " + user);
            }

        
        
        
        }

    }

}
