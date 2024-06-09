namespace _03._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int maxRow = 0;
            int maxCol = 0;
            int sum = 0;

            int[,] matrix = new int[rows, cols];
            int count = 0;
            for (int row = 0; row < rows; row++)
            {
                int[] rowArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowArr[col];
                }
            }
            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {

                    int newSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        +matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (newSum > sum)
                    {
                        maxRow = row;
                        maxCol = col;
                        sum = newSum;
                    }
                }
            }

            Console.WriteLine("Sum = " + sum);
            for (int row = maxRow; row <= maxRow + 2; row++)
            {
                for (int col = maxCol; col <= maxCol + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
