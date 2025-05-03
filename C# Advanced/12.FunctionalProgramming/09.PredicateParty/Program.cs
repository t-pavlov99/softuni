using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _09.PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> names = new Dictionary<string, int>();
            string[] invited = Console.ReadLine().Split(" ").ToArray();
            foreach (string name in invited)
            {
                names.Add(name, 1);
            }
            string cmd;
            while ((cmd = Console.ReadLine()) != "Party!")
            {
                string[] parameters = cmd.Split(" ");
                names = names.Select(Apply(parameters[0], parameters[1], parameters[2]))
                    .ToDictionary(k => k.Key, v => v.Value);
            }

            string toPrint = string.Join(", ", names.Select(x => RepeatName(x.Key, x.Value)).Where(x => x != null));
            if (toPrint == string.Empty)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{toPrint} are going to the party!");
            }
        }
        static Func<string, bool> Match(string cmd, string str)
        {
            switch (cmd)
            {
                case "StartsWith": return x => x.StartsWith(str);
                case "EndsWith": return x => x.EndsWith(str);
                case "Length": return x => x.Length == int.Parse(str);
                default:
                    throw new ArgumentException(cmd);
            }
        }

        static Func<KeyValuePair<string, int>, KeyValuePair<string, int>> Apply(string cmd, string type, string param)
        {
            switch (cmd)
            {
                case "Double": return x => (Match(type, param)(x.Key)) ? new KeyValuePair<string, int>(x.Key, x.Value * 2) : x;
                case "Remove": return x => (Match(type, param)(x.Key)) ? new KeyValuePair<string, int>(x.Key, 0) : x;
                default: throw new ArgumentException(cmd);
            }
        }

        static string RepeatName(string name, int n)
        {
            if (n == 0) return null;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n - 1; i++)
            {
                sb.Append(name + ", ");
            }
            sb.Append(name);
            return sb.ToString();
        }
    }
}
