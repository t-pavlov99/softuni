using System.Threading.Channels;
/*
Part One Interview:success
Js Fundamentals:JSFundPass
C# Fundamentals:fundPass
Algorithms:fun
end of contests
C# Fundamentals=>fundPass=>Tanya=>350
Algorithms=>fun=>Tanya=>380
Part One Interview=>success=>Nikola=>120
Java Basics
Exam=>JSFundPass=>Parker=>400
Part One Interview=>success=>Tanya=>220
OOP Advanced=>password123=>BaiIvan=>231
C# Fundamentals=>fundPass=>Tanya=>250
C# Fundamentals=>fundPass=>Nikola=>200
Js Fundamentals=>JSFundPass=>Tanya=>400
end of submissions

Java Advanced:funpass
Part Two Interview:success
Math Concept:asdasd
Java Web Basics:forrF
end of contests
Math Concept=>ispass=>Monika=>290
Java Advanced=>funpass=>Simon=>400
Part Two Interview=>success=>Drago=>120
Java Advanced=>funpass=>Petyr=>90
Java Web Basics=>forrF=>Simon=>280
Part Two Interview=>success=>Petyr=>0
Math Concept=>asdasd=>Drago=>250
Part Two Interview=>success=>Simon=>200
end of submissions
 */
namespace _08.Ranking
{
    internal class Program
    {
        static Dictionary<string, string> contests;
        static Dictionary<string, Dictionary<string, int>> users;
        static void Main(string[] args)
        {
            contests = new();
            users = new();
            string cmd;
            while ((cmd = Console.ReadLine()) != "end of contests")
            {
                string[] parts = cmd.Split(":");
                contests.Add(parts[0], parts[1]);
            }
            while ((cmd = Console.ReadLine()) != "end of submissions")
            {
                string[] parts = cmd.Split("=>");
                if (!contests.ContainsKey(parts[0]))
                    continue;
                if (contests[parts[0]] != parts[1])
                    continue;
                if (!users.ContainsKey(parts[2]))
                    users.Add(parts[2], new());
                if (!users[parts[2]].ContainsKey(parts[0]))
                    users[parts[2]].Add(parts[0], 0);
                int score = int.Parse(parts[3]);
                if (score >= users[parts[2]][parts[0]])
                {
                    users[parts[2]][parts[0]] = score;
                }
            }
            var sorted = users.OrderByDescending(x => x.Value.Sum(x => x.Value));
            Console.WriteLine($"Best candidate is {sorted.First().Key} with total {sorted.First().Value.Sum(x => x.Value)} points.");
            sorted = sorted.OrderBy(x => x.Key);
            Console.WriteLine("Ranking:");
            foreach (var user in sorted)
            {
                Console.WriteLine(user.Key);
                var sortedContests = user.Value.OrderByDescending(x => x.Value);
                foreach (var result in sortedContests)
                {
                    Console.WriteLine($"#  {result.Key} -> {result.Value}");
                }
            }
        }   


    }
}
