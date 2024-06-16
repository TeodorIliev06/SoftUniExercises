namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            byte[] fileContent = File.ReadAllBytes(sourceFilePath);

            int splitPoint = fileContent.Length / 2;
            int firstPartSize = splitPoint + (fileContent.Length % 2);

            byte[] partOne = new byte[firstPartSize];
            byte[] partTwo = new byte[fileContent.Length - firstPartSize];

            Array.Copy(fileContent, 0, partOne, 0, firstPartSize);
            Array.Copy(fileContent, firstPartSize, partTwo, 0, fileContent.Length - firstPartSize);

            File.WriteAllBytes(partOneFilePath, partOne);
            File.WriteAllBytes(partTwoFilePath, partTwo);
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            byte[] partOne = File.ReadAllBytes(partOneFilePath);
            byte[] partTwo = File.ReadAllBytes(partTwoFilePath);

            byte[] mergedContent = new byte[partOne.Length + partTwo.Length];
            Array.Copy(partOne, 0, mergedContent, 0, partOne.Length);
            Array.Copy(partTwo, 0, mergedContent, partOne.Length, partTwo.Length);

            File.WriteAllBytes(joinedFilePath, mergedContent);
        }
    }
}