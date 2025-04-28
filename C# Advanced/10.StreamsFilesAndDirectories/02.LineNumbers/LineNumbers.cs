namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] input = File.ReadAllLines(inputFilePath);
            for (int i = 0; i < input.Length; i++)
            {
                int punctCount = 0;
                int letterCount = 0;
                foreach (char c in input[i])
                {
                    if (c == '.' || c == '-' || c == ',' || c == '!' || c == '?' || c == '\'')
                        punctCount++;
                    if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                    
                        letterCount++;
                    
                }
                input[i] = $"Line {i+1}: {input[i]} ({letterCount})({punctCount})";
            }
            File.WriteAllLines(outputFilePath, input);

        }
    }
}
