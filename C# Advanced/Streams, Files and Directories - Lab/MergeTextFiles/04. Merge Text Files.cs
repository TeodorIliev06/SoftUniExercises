namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            string[] firstLines = File.ReadAllLines(firstInputFilePath);
            string[] secondLines = File.ReadAllLines(secondInputFilePath);

            int maxLines = Math.Max(firstLines.Length, secondLines.Length);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                for (int i = 0; i < maxLines; i++)
                {
                    if (i < firstLines.Length)
                    {
                        writer.WriteLine(firstLines[i]);
                    }

                    if (i < secondLines.Length)
                    {
                        writer.WriteLine(secondLines[i]);
                    }
                }
            }
        }
    }
}
