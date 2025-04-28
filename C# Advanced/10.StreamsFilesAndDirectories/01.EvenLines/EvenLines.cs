namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StringBuilder sb = new();
            bool count = true;
            using (reader)
            {
                while (true)
                {

                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    if (count == true)
                    {
                        Regex regex = new(@"[.,-?!]");
                        line = regex.Replace(line, "@");
                        
                        sb.AppendLine(string.Join(" ", line.Split(' ').Reverse()));
                    }
                    count = !count;
                }
            }
            return sb.ToString();
        }
    }
}
