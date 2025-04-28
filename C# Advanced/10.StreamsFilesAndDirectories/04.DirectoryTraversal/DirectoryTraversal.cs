namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(inputFolderPath);
            FileInfo[] fileInfo = directoryInfo.GetFiles();
            Dictionary<string, int> extensions = new();
            foreach (FileInfo file in fileInfo)
            {
                string extension = file.Extension;
                if (!extensions.ContainsKey(extension))
                    extensions.Add(extension, 0);
                extensions[extension]++;
            }
            StringBuilder sb = new();
            string[] sorted = extensions.OrderByDescending(x => x.Value)
                                        .ThenBy(x => x.Key)
                                        .Select(x => x.Key)
                                        .ToArray();
            foreach (string ext in sorted)
            {
                sb.AppendLine(ext);
                sb.AppendLine(string.Join("\n", fileInfo.Where(x => x.Extension == ext)
                                                    .OrderBy(x => x.Length)
                                                    .Select(x => $"-- {x.Name} - {x.Length / 1024m}kb")));
            }
            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = desktop + reportFileName;
            File.WriteAllText(path, textContent);
        }
    }
}
