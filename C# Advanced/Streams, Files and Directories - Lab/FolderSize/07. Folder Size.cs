namespace FolderSize
{
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            long size = ReadFiles(folderPath);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine($"{size / 1024.0} KB");
            }
        }

        public static long ReadFiles(string folderPath, int levels = 0)
        {
            string[] files = Directory.GetFiles(folderPath);
            long size = 0;

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                size += fileInfo.Length;
            }

            string[] directories = Directory.GetDirectories(folderPath);

            foreach (string dir in directories)
            {
                size += ReadFiles(dir, levels + 1);
            }

            return size;
        }
    }
}
