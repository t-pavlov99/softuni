namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            DirectoryInfo info = new DirectoryInfo(inputPath);
            string newLocation = Path.Combine(outputPath, info.Name);
            if (Directory.Exists(newLocation))
                Directory.Delete(newLocation, true);
            Directory.CreateDirectory(newLocation);
            FileInfo[] files = info.GetFiles();
            foreach (FileInfo file in files)
            {
                File.Copy(Path.Combine(inputPath, file.Name), newLocation);
            }
        }
    }
}
