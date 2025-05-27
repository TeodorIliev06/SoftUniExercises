using System.Collections.Generic;
using System.Text;

namespace Zad_28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = ReadMatrix(@"..\..\..\table.txt");
            var words = ReadWords(@"..\..\..\words.txt");

            foreach (var word in words) 
            {
                if (Contains(matrix, word)) 
                {
                    Console.WriteLine(word);
                }
            }
        }

        public static bool Contains(char[,] matrix, string input)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sb.Clear();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(matrix[i, j]);
                }

                var currentRow = sb.ToString();
                var reversedCurrentRow = new string(currentRow.Reverse().ToArray());

                if (currentRow.Contains(input) ||
                    reversedCurrentRow.Contains(input))
                {
                    return true;
                }
            }

            return false;
        }

        public static char[,] ReadMatrix(string path) 
        {
            char[,] matrix = null;
            int rowsCount = CountRowsInFile(path);
            int matrixSize = 0, currentLine = 0;
            bool isInitialised = false;

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        try
                        {
                            if (!isInitialised)
                            {
                                matrixSize = line.Length;
                                matrix = new char[rowsCount, matrixSize];
                                isInitialised = true;
                            }

                            if (matrixSize != line.Length)
                            {
                                Console.WriteLine("Invalid format! Matrix should be rectangular.");
                                return null;
                            }

                            var currentRow = line.ToCharArray();
                            for (int i = 0; i < matrixSize; i++) 
                            {
                                matrix[currentLine, i] = currentRow[i];
                            }

                            currentLine++;
                        }
                        catch (FormatException ex)
                        {
                            throw new FormatException(ex.Message);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }

            return matrix;
        }

        public static List<string> ReadWords(string path)
        {
            var list = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        try
                        {
                            list.Add(line);
                        }
                        catch (FormatException ex)
                        {
                            throw new FormatException(ex.Message);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }


            return list;
        }

        public static int CountRowsInFile(string path)
        {
            int rowCount = 0;

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.ReadLine() != null) // Read each line until the end
                    {
                        rowCount++; // Increment the row count for each line
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The specified file was not found.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }

            return rowCount;
        }
    }
}
