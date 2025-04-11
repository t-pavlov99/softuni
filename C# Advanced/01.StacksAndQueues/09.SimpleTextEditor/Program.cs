using System.Text.RegularExpressions;

/*
8
1 abc
3 3
2 3
1 xy
3 2
4
4
3 1

9
1 HelloThere
3 7
2 2
3 5
4
3 7
4
1 TestPassed
3 5
 */
namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            int n = int.Parse(Console.ReadLine());
            Stack<Operation> operations = new();
            for (int i = 0; i < n; i++)
            {
                Match cmd = Regex.Match(Console.ReadLine(), @"([1-4])(?: (.+))?");
                switch (cmd.Groups[1].Value)
                {
                    case "1":
                    case "2":
                        operations.Push(new Operation(cmd.Groups[1].Value, cmd.Groups[2].Value));
                        text = operations.Peek().Do(text);
                        break;
                    case "3":
                        Console.WriteLine(text[int.Parse(cmd.Groups[2].Value) - 1]);
                        break;
                    case "4":
                        text = operations.Pop().Undo(text);
                        break;
                    default:
                        break;
                }
            }
        }


        public class Operation
        {
            public Operation(string n, string info)
            {
                Type = (n == "1") ? Type.Append : Type.Erase;
                Info = info;
            }

            public Type Type { get; set; }
            public string Info { get; set; }

            private string Erased { get; set; }

            public string Do(string str)
            {
                switch (Type)
                {
                    case Type.Append:
                        return str + Info;
                    case Type.Erase:
                        int count = int.Parse(Info);
                        Erased = str.Substring(str.Length - count);
                        return str.Substring(0, str.Length - count);
                    default:
                        return null;
                }
            }

            public string Undo(string str)
            {
                switch (Type)
                {
                    case Type.Append:
                        return str.Substring(0, str.Length - Info.Length);
                    case Type.Erase:
                        return str + Erased;
                    default:
                        return null;
                }
            }
        }

        public enum Type
        {
            Append, Erase
        }
    }
}
