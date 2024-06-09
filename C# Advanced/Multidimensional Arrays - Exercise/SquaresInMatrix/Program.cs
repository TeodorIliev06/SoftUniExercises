namespace _02._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int squaresMatrices = 0;
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var rowArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowArr[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1]
                        && matrix[row, col] == matrix[row + 1, col]
                        && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        squaresMatrices++;
                    }
                }
            }

            Console.WriteLine(squaresMatrices);
        }
    }
}
