using System.Text.RegularExpressions;

namespace _08.BalancedParanthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BalancedBrackets(Console.ReadLine()) ? "YES" : "NO");
        }

        static bool BalancedBrackets(string str)
        {
            string pattern = @"[\(\)\{\}\[\]]";
            string brackets = string.Join("", Regex.Matches(str, pattern).Select(m => m.Groups[0].Value));
            Dictionary<char, char> parentheses = new Dictionary<char, char> { { '(', ')' }, { '[', ']' }, { '{', '}' } };
            Stack<char> stack = new();
            for (int i = 0; i < brackets.Length; i++)
            {
                switch (brackets[i])
                {
                    case '{':
                    case '[':
                    case '(':
                        stack.Push(brackets[i]);
                        break;
                    default:
                        if (stack.Count == 0)
                            return false;
                        if (parentheses[stack.Pop()] != brackets[i])
                            return false;
                        break;
                    /*case '}':
                        if (stack.Count == 0)
                            return false;
                        if (stack.Pop() != '{')
                            return false;
                        break;
                    case ']':
                        if (stack.Count == 0)
                            return false;
                        if (stack.Pop() != '[')
                            return false;
                        break;
                    case ')':
                        if (stack.Count == 0)
                            return false;
                        if (stack.Pop() != '(')
                            return false;
                        break;*/

                }
            }
            return stack.Count == 0;
        }
    }
}
