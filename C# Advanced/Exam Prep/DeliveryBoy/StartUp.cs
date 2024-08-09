using System;
using System.Linq;

namespace DeliveryBoy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] matrix = new char[rows, cols];

            int personRow = -1;
            int personCol = -1;

            int initialPersonRow = -1;
            int initialPersonCol = -1;

            for (int row = 0; row < rows; row++)
            {
                char[] rowArr = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowArr[col];

                    if (matrix[row, col] == 'B')
                    {
                        personRow = row;
                        personCol = col;
                        initialPersonRow = row;
                        initialPersonCol = col;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "left")
                {
                    if (personCol > 0)
                    {
                        if (matrix[personRow, personCol - 1] == '*')
                            continue;

                        if (matrix[personRow, personCol] != 'R')
                            matrix[personRow, personCol] = '.';

                        personCol--;
                    }
                    else
                    {
                        if (matrix[personRow, personCol] == '-')
                        {
                            matrix[personRow, personCol] = '.';
                        }
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        matrix[initialPersonRow, initialPersonCol] = ' ';
                        PrintMatrix(rows, cols, matrix);
                        return;
                    }
                }

                if (command == "right")
                {
                    if (personCol < cols - 1)
                    {
                        if (matrix[personRow, personCol + 1] == '*')
                            continue;

                        if (matrix[personRow, personCol] != 'R')
                            matrix[personRow, personCol] = '.';

                        personCol++;
                    }
                    else
                    {
                        if (matrix[personRow, personCol] == '-')
                        {
                            matrix[personRow, personCol] = '.';
                        }
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        matrix[initialPersonRow, initialPersonCol] = ' ';
                        PrintMatrix(rows, cols, matrix);
                        return;
                    }
                }

                if (command == "up")
                {
                    if (personRow > 0)
                    {
                        if (matrix[personRow - 1, personCol] == '*')
                            continue;

                        if (matrix[personRow, personCol] != 'R')
                            matrix[personRow, personCol] = '.';

                        personRow--;
                    }
                    else
                    {
                        if (matrix[personRow, personCol] == '-')
                        {
                            matrix[personRow, personCol] = '.';
                        }
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        matrix[initialPersonRow, initialPersonCol] = ' ';
                        PrintMatrix(rows, cols, matrix);
                        return;
                    }
                }

                if (command == "down")
                {
                    if (personRow < rows - 1)
                    {
                        if (matrix[personRow + 1, personCol] == '*')
                            continue;

                        if (matrix[personRow, personCol] != 'R')
                            matrix[personRow, personCol] = '.';

                        personRow++;
                    }
                    else
                    {
                        if (matrix[personRow, personCol] == '-')
                        {
                            matrix[personRow, personCol] = '.';
                        }
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        matrix[initialPersonRow, initialPersonCol] = ' ';
                        PrintMatrix(rows, cols, matrix);
                        return;
                    }
                }

                if (matrix[personRow, personCol] == 'P')
                {
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                    matrix[personRow, personCol] = 'R';
                    continue;
                }

                if (matrix[personRow, personCol] == 'A')
                {
                    matrix[personRow, personCol] = 'P';
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    break;
                }
            }

            matrix[initialPersonRow, initialPersonCol] = 'B';
            PrintMatrix(rows, cols, matrix);
        }

        public static void PrintMatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}