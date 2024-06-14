namespace ExtractSpecialBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            string[] byteStrings = File.ReadAllLines(bytesFilePath);
            List<byte> bytesToExtract = new List<byte>();

            foreach (string byteString in byteStrings)
            {
                if (byte.TryParse(byteString, out byte byteValue))
                {
                    bytesToExtract.Add(byteValue);
                }                
            }

            byte[] fileContent = File.ReadAllBytes(binaryFilePath);

            List<byte> extractedBytes = new List<byte>();
            foreach (byte byteToExtract in bytesToExtract)
            {
                foreach (byte fileByte in fileContent)
                {
                    if (fileByte == byteToExtract)
                    {
                        extractedBytes.Add(fileByte);
                    }
                }
            }

            File.WriteAllBytes(outputPath, extractedBytes.ToArray());
        }
    }
}
