using System;
using System.IO;

namespace CopyDirectory
{
    public class CopyDirectory
    {
        static void Main()
        {
            Console.WriteLine("Enter the input directory path:");
            string inputPath = @$"{Console.ReadLine()}";

            Console.WriteLine("Enter the output directory path:");
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {

            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true); // Deleting recursively
            }

            Directory.CreateDirectory(outputPath);

            string[] files = Directory.GetFiles(inputPath);

            // Copy files to the output directory
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(outputPath, fileName);
                File.Copy(file, destFile);
            }

            Console.WriteLine("Directory copied successfully.");
        }
    }
}
