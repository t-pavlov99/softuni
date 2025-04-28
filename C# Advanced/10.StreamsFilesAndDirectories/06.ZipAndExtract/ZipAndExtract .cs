namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";
            
            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            string temp = @"VERYTEMPORARY";
            string fileName = Path.GetFileName(inputFilePath);
            Directory.CreateDirectory(temp);
            File.Copy(inputFilePath, Path.Combine(temp, fileName));
            ZipFile.CreateFromDirectory(temp, zipArchiveFilePath);
            Directory.Delete(temp, true);
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            string temp = @"VERYTEMPORARY";
            Directory.CreateDirectory(temp);
            ZipFile.ExtractToDirectory(zipArchiveFilePath, temp);
            File.Copy(Path.Combine(temp, fileName), outputFilePath);
            Directory.Delete(temp, true);
        }
    }
}
