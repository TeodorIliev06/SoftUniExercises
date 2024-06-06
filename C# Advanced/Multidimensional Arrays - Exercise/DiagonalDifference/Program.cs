namespace _01._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            for (int row = 0; row < matrixSize; row++)
            {
                firstDiagonalSum += matrix[row, row];
            }

            for (int row = 0; row < matrixSize; row++)
            {
                secondDiagonalSum += matrix[row, matrixSize - row - 1];
            }
            Console.WriteLine(Math.Abs(firstDiagonalSum - secondDiagonalSum));
        }
    }
}
