using System;
using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFilePath = "copyMe.png";
            string zipArchiveFilePath = "archive.zip";
            string extractedFilePath = "extracted.png";

            ZipFileToArchive(inputFilePath, zipArchiveFilePath);
            ExtractFileFromArchive(zipArchiveFilePath, Path.GetFileName(inputFilePath), extractedFilePath);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        { 
            // Create a new ZIP archive and add the input file to it
            using (FileStream zipToOpen = new FileStream(zipArchiveFilePath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry entry = archive.CreateEntry(Path.GetFileName(inputFilePath));

                    using (Stream writer = entry.Open())
                    {
                        using (FileStream fileToCompress = new FileStream(inputFilePath, FileMode.Open))
                        {
                            fileToCompress.CopyTo(writer);
                        }
                    }
                }
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            // Extract the file from the ZIP archive
            using (ZipArchive archive = ZipFile.OpenRead(zipArchiveFilePath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.Equals(fileName, StringComparison.OrdinalIgnoreCase))
                    {
                        entry.ExtractToFile(outputFilePath, true);
                        break;
                    }
                }
            }

        }
    }
}
