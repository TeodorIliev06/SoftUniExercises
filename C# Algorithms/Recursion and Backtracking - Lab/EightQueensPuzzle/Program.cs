using System;

namespace EightQueensPuzzle
{
    internal class Program
    {
        private static int matrixSize = 8;
        static void Main(string[] args)
        {
            int[,] matrix = new int[matrixSize, matrixSize];

            GetQueens(matrix, 0);
        }

        //Using backtracking
        private static void GetQueens(int[,] queens, int row)
        {
            if (row == queens.GetLength(0))
            {
                PrintQueens(queens);
                Console.WriteLine();
                return;
            }

            for (int col = 0; col < queens.GetLength(1); col++)
            {
                //Always set to initial value after making a recursion
                if (IsSafe(queens, col, row))
                {
                    queens[row, col] = 1;
                    GetQueens(queens, row + 1);
                    queens[row, col] = 0;
                }
            }
        }

        private static bool IsSafe(int[,] queens, int col, int row)
        {
            for (int i = 0; i < queens.GetLength(0); i++)
            {
                //Check the four directions
                if (row - i >= 0 && queens[row - i, col] == 1)
                {
                    return false;
                }
                if (col - i >= 0 && queens[row, col - i] == 1)
                {
                    return false;
                }
                if (row + i < queens.GetLength(0) && queens[row + i, col] == 1)
                {
                    return false;
                }
                if (col + i < queens.GetLength(0) && queens[row, col + i] == 1)
                {
                    return false;
                }

                //Check diagonals
                if (col + i < queens.GetLength(0) &&
                    row + i < queens.GetLength(0) &&
                    queens[row + i, col + i] == 1)
                {
                    return false;
                }
                if (col - i >= 0 &&
                    row + i < queens.GetLength(0) &&
                    queens[row + i, col - i] == 1)
                {
                    return false;
                }
                if (col + i < queens.GetLength(0) &&
                    row - i >= 0 &&
                    queens[row - i, col + i] == 1)
                {
                    return false;
                }
                if (col - i >= 0 &&
                    row - i >= 0 &&
                    queens[row - i, col - i] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        private static void PrintQueens(int[,] queens)
        {
            for (int row = 0; row < queens.GetLength(0); row++)
            {
                for (int col = 0; col < queens.GetLength(1); col++)
                {
                    if (queens[row, col] == 1)
                    {
                        Console.Write("*" + " ");
                    }
                    if (queens[row, col] == 0)
                    {
                        Console.Write("-" + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
