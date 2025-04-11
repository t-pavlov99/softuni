using System.Threading.Channels;
/*
Peter-Java-84
George-C#-70
George-C#-84
Sam-C#-94
exam finished

Peter-Java-91
George-C#-84
Sam-JavaScript-90
Sam-C#-50
Sam-banned
exam finished
 */
namespace _09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, (int, Dictionary<string, int>)> languages = new();

            string cmd;

            while ((cmd = Console.ReadLine()) != "exam finished")
            {
                string[] parts = cmd.Split('-');

                if (parts[1] == "banned")
                {
                    foreach (var language in languages)
                    {
                        language.Value.Item2.Remove(parts[0]);
                    }
                }
                else
                {
                    string user = parts[0];
                    string language = parts[1];
                    int value = int.Parse(parts[2]);
                    if (!languages.ContainsKey(language))
                        languages.Add(language, (0, new()));
                    if (!languages[language].Item2.ContainsKey(user))
                        languages[language].Item2.Add(user, 0);
                    languages[language].Item2[user] = Math.Max(languages[language].Item2[user], int.Parse(parts[2]));
                    languages[language] = new(languages[language].Item1 + 1, languages[language].Item2);
                }
            }
            Dictionary<string, int> results = new();
            foreach (var language in languages)
            {
                foreach (var result in language.Value.Item2)
                {
                    if (!results.ContainsKey(result.Key))
                        results.Add(result.Key, 0);
                    results[result.Key] += result.Value;
                }
            }
            var orderedLanguages = languages.OrderByDescending(x => x.Value.Item1).ThenBy(x => x.Key);
            var orderedResults = results.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
            
            Console.WriteLine("Results:");
            Console.WriteLine(string.Join("\n", orderedResults.Select(x => $"{x.Key} | {x.Value}")));
            Console.WriteLine("Submissions:");
            Console.WriteLine(string.Join("\n", orderedLanguages.Select(x => $"{x.Key} - {x.Value.Item1}")));

        }
        
    }
}
