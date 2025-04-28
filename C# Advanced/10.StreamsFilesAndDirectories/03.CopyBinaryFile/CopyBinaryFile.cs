namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream input = new FileStream(inputFilePath, FileMode.Open))
            using (FileStream output = new FileStream(outputFilePath, FileMode.Create))
            {
                byte[] buffer = new byte[1024];
                while (true)
                {
                    int count = input.Read(buffer);
                    if (count == 0)
                        break;
                    output.Write(buffer);
                }
            }
        }
    }
}
