using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    public class DirectoryTraversal
    {
        static void Main()
        {
            Console.WriteLine("Enter the path of the directory:");
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, List<FileInfo>> filesByExtension = new Dictionary<string, List<FileInfo>>();

            if (!Directory.Exists(inputFolderPath))
            {
                return "Directory does not exist!";
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(inputFolderPath);
            FileInfo[] files = directoryInfo.GetFiles();

            foreach (var file in files)
            {
                string extension = file.Extension;
                if (!filesByExtension.ContainsKey(extension))
                {
                    filesByExtension[extension] = new List<FileInfo>();
                }
                filesByExtension[extension].Add(file);
            }

            var sortedExtensions = filesByExtension.OrderByDescending(kv => kv.Value.Count)
                                                   .ThenBy(kv => kv.Key);

            string reportContent = "";
            foreach (var extensionGroup in sortedExtensions)
            {
                reportContent += $"Extension: {extensionGroup.Key}\n";

                var sortedFiles = extensionGroup.Value.OrderBy(f => f.Length);

                foreach (var file in sortedFiles)
                {
                    reportContent += $"\t{file.Name} - {file.Length} bytes\n";
                }
            }

            return reportContent;
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string reportFilePath = desktopPath + reportFileName;

            File.WriteAllText(reportFilePath, textContent);
            Console.WriteLine($"Report saved to {reportFilePath}");
        }
    }
}
