﻿namespace _01._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = ReadIntArr();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int sum = 0;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowArr = ReadIntArr();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowArr[col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    sum+= matrix[row, col];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }

        private static int[] ReadIntArr()
        {
            return Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
        }
    }
}
