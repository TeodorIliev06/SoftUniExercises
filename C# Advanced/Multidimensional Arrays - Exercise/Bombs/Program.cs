namespace _08._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                int[] rowArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = rowArr[col];
                }
            }

            string[] bombs = Console.ReadLine().Split();

            for (int i = 0; i < bombs.Length; i++)
            {
                string[] currBombCoordinates = bombs[i].Split(",");
                int bombRow = int.Parse(currBombCoordinates[0]);
                int bombCol = int.Parse(currBombCoordinates[1]);
                int bombValue = matrix[bombRow, bombCol];

                if (bombValue > 0) //See which cells can be bombed
                {

                    if (ValidBombCoordinates(matrix, bombRow - 1, bombCol - 1) &&
                        matrix[bombRow - 1, bombCol - 1] > 0 && //Top left
                        matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol - 1] -= matrix[bombRow, bombCol];
                    }

                    if (ValidBombCoordinates(matrix, bombRow - 1, bombCol) &&
                        matrix[bombRow - 1, bombCol] > 0 && //Top mid
                        matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol] -= matrix[bombRow, bombCol];
                    }

                    if (ValidBombCoordinates(matrix, bombRow - 1, bombCol + 1) &&
                        matrix[bombRow - 1, bombCol + 1] > 0 && //Top right
                        matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol + 1] -= matrix[bombRow, bombCol];
                    }

                    if (ValidBombCoordinates(matrix, bombRow, bombCol - 1) &&
                        matrix[bombRow, bombCol - 1] > 0 && //Mid left
                        matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow, bombCol - 1] -= matrix[bombRow, bombCol];
                    }

                    if (ValidBombCoordinates(matrix, bombRow, bombCol + 1) &&
                        matrix[bombRow, bombCol + 1] > 0 && //Mid right
                        matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow, bombCol + 1] -= matrix[bombRow, bombCol];
                    }

                    if (ValidBombCoordinates(matrix, bombRow + 1, bombCol - 1) &&
                        matrix[bombRow + 1, bombCol - 1] > 0 && //Bottom left
                        matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol - 1] -= matrix[bombRow, bombCol];
                    }

                    if (ValidBombCoordinates(matrix, bombRow + 1, bombCol) &&
                        matrix[bombRow + 1, bombCol] > 0 && //Bottom mid
                        matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol] -= matrix[bombRow, bombCol];
                    }

                    if (ValidBombCoordinates(matrix, bombRow + 1, bombCol + 1) &&
                        matrix[bombRow + 1, bombCol + 1] > 0 && //Bottom right
                        matrix[bombRow, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol + 1] -= matrix[bombRow, bombCol];
                    }

                    matrix[bombRow, bombCol] = 0; //Center
                }
            }

            int aliveCells = 0;
            int aliveCellsSum = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        aliveCellsSum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {aliveCellsSum}");

            PrintMatrix(matrixSize, matrix);

        }

        private static void PrintMatrix(int matrixSize, int[,] matrix)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool ValidBombCoordinates(int[,] matrix, int bombRow, int bombCol)
        {
            return bombRow >= 0 && bombRow < matrix.GetLength(0) &&
                bombCol >= 0 && bombCol < matrix.GetLength(1);
        }
    }
}
